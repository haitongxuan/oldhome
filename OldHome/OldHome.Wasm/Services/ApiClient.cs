using OldHome.API.Services;
using OldHome.DTO;
using OldHome.DTO.Base;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;
using Microsoft.AspNetCore.Components;

namespace OldHome.Wasm.Services
{
    public class ApiClient : IApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly Func<Task<SignInResponse?>>? _refreshTokenFunc;
        private readonly IUserSessionService _userSessionService;

        public ApiClient(HttpClient httpClient, IUserSessionService userSessionService, Func<Task<SignInResponse?>>? refreshTokenFunc = null)
        {
            _httpClient = httpClient;
            _refreshTokenFunc = refreshTokenFunc;
            _userSessionService = userSessionService;
        }

        private void AddJwtHeader()
        {
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", _userSessionService.Token);

            if (_userSessionService.OrgId is not null)
            {
                if (_httpClient.DefaultRequestHeaders.Contains("OrgId"))
                    _httpClient.DefaultRequestHeaders.Remove("OrgId");
                _httpClient.DefaultRequestHeaders.Add("OrgId", _userSessionService.OrgId.ToString());
            }
        }

        public async Task<BaseResponse<T>?> GetAsync<T>(string url)
        {
            return await ExecuteWithRetryGeneric(async () =>
            {
                AddJwtHeader();
                var response = await _httpClient.GetAsync(url);
                return GetResponse<T>(response);
            });
        }

        public async Task<BaseResponse<T>?> PostAsync<TRequest, T>(string url, TRequest request)
        {
            return await ExecuteWithRetryGeneric(async () =>
            {
                AddJwtHeader();
                string json = JsonSerializer.Serialize(request);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(url, content);
                return GetResponse<T>(response);
            });
        }

        public async Task<BaseResponse?> GetAsync(string url)
        {
            return await ExecuteWithRetry(async () =>
            {
                AddJwtHeader();
                var response = await _httpClient.GetAsync(url);
                return GetResponse(response);
            });
        }

        public async Task<BaseResponse?> PostAsync<TRequest>(string url, TRequest request)
        {
            return await ExecuteWithRetry(async () =>
            {
                AddJwtHeader();
                string json = JsonSerializer.Serialize(request);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(url, content);
                return GetResponse(response);
            });
        }

        private async Task<BaseResponse<T>?> ExecuteWithRetryGeneric<T>(Func<Task<BaseResponse<T>>> operation)
        {
            try
            {
                var result = await operation();

                // 如果是401错误且可以刷新令牌，尝试刷新一次
                if (result.StatusCode == System.Net.HttpStatusCode.Unauthorized && _refreshTokenFunc != null)
                {
                    var oldToken = _userSessionService.Token;
                    var refreshResult = await _refreshTokenFunc.Invoke();

                    if (refreshResult != null && !string.IsNullOrEmpty(refreshResult.Token))
                    {
                        _userSessionService.SetSession(refreshResult.UserName, refreshResult.Token, refreshResult.Role, refreshResult.OrgId);

                        // 只有当令牌真的更新了才重试
                        if (refreshResult.Token != oldToken)
                        {
                            var retryResult = await operation();

                            // 如果重试后仍然是401，说明令牌问题无法解决
                            if (retryResult.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                            {
                                throw new UnauthorizedAccessException("Token 过期且刷新后仍然无效。");
                            }

                            return retryResult;
                        }
                    }

                    throw new UnauthorizedAccessException("Token 过期且刷新失败。");
                }

                // 对于其他错误，直接抛出异常
                if (!result.IsSuccess)
                {
                    throw new HttpRequestException($"HTTP {result.StatusCode}:\n{result.Message}");
                }

                return result;
            }
            catch (UnauthorizedAccessException)
            {
                throw; // 重新抛出授权异常
            }
            catch (HttpRequestException)
            {
                throw; // 重新抛出HTTP请求异常
            }
            catch (Exception ex)
            {
                // 对于其他异常，包装为对应的响应类型
                var errorResponse = new BaseResponse<T>
                {
                    IsSuccess = false,
                    Message = ex.Message,
                    StatusCode = System.Net.HttpStatusCode.InternalServerError
                };
                return errorResponse;
            }
        }

        private async Task<BaseResponse?> ExecuteWithRetry(Func<Task<BaseResponse>> operation)
        {
            try
            {
                var result = await operation();

                // 如果是401错误且可以刷新令牌，尝试刷新一次
                if (result.StatusCode == System.Net.HttpStatusCode.Unauthorized && _refreshTokenFunc != null)
                {
                    var oldToken = _userSessionService.Token;
                    var refreshResult = await _refreshTokenFunc.Invoke();

                    if (refreshResult != null && !string.IsNullOrEmpty(refreshResult.Token))
                    {
                        _userSessionService.SetSession(refreshResult.UserName, refreshResult.Token, refreshResult.Role, refreshResult.OrgId);

                        // 只有当令牌真的更新了才重试
                        if (refreshResult.Token != oldToken)
                        {
                            var retryResult = await operation();

                            // 如果重试后仍然是401，说明令牌问题无法解决
                            if (retryResult.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                            {
                                throw new UnauthorizedAccessException("Token 过期且刷新后仍然无效。");
                            }

                            return retryResult;
                        }
                    }

                    throw new UnauthorizedAccessException("Token 过期且刷新失败。");
                }

                // 对于其他错误，直接抛出异常
                if (!result.IsSuccess)
                {
                    throw new HttpRequestException($"HTTP {result.StatusCode}:\n{result.Message}");
                }

                return result;
            }
            catch (UnauthorizedAccessException)
            {
                throw; // 重新抛出授权异常
            }
            catch (HttpRequestException)
            {
                throw; // 重新抛出HTTP请求异常
            }            
        }

        private BaseResponse<T> GetResponse<T>(HttpResponseMessage response)
        {
            var json = response.Content.ReadAsStringAsync().Result;
            var result = new BaseResponse<T>();
            result.IsSuccess = response.IsSuccessStatusCode;
            if (response.IsSuccessStatusCode)
            {
                result.Data = JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            result.StatusCode = response.StatusCode;
            result.Message = response.ReasonPhrase;
            return result;
        }

        private BaseResponse GetResponse(HttpResponseMessage response)
        {
            var json = response.Content.ReadAsStringAsync().Result;
            var result = new BaseResponse();
            result.IsSuccess = response.IsSuccessStatusCode;
            result.StatusCode = response.StatusCode;
            result.Message = response.ReasonPhrase;
            return result;
        }
    }
}