using OldHome.API.Services;
using OldHome.DTO;
using OldHome.DTO.Base;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace OldHome.Wasm.Services
{
    public class ApiClient : IApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly IUserSessionService _userSessionService;
        private readonly IJSRuntime _jsRuntime;
        private readonly NavigationManager _navigationManager;
        private bool _isRefreshing = false;
        private readonly SemaphoreSlim _refreshSemaphore = new(1, 1);

        public ApiClient(HttpClient httpClient, IUserSessionService userSessionService, IJSRuntime jSRuntime, NavigationManager navigationManager)
        {
            _httpClient = httpClient;
            _userSessionService = userSessionService;
            _jsRuntime = jSRuntime;
            _navigationManager = navigationManager;
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
                return await GetResponse<T>(response);
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
                return await GetResponse<T>(response);
            });
        }

        public async Task<BaseResponse?> GetAsync(string url)
        {
            return await ExecuteWithRetry(async () =>
            {
                AddJwtHeader();
                var response = await _httpClient.GetAsync(url);
                return await GetResponse(response);
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
                return await GetResponse(response);
            });
        }

        private async Task<BaseResponse<T>?> ExecuteWithRetryGeneric<T>(Func<Task<BaseResponse<T>>> operation)
        {
            try
            {
                var result = await operation();

                // 如果是401错误，尝试刷新令牌
                if (result.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    var refreshed = await RefreshTokenAsync();

                    if (refreshed)
                    {
                        // 重试原始请求
                        result = await operation();

                        if (result.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                        {
                            // 刷新后仍然401，跳转到登录页
                            await NavigateToLogin();
                        }
                    }
                    else
                    {
                        // 刷新失败，跳转到登录页
                        await NavigateToLogin();
                    }
                }

                return result;
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

                // 如果是401错误，尝试刷新令牌
                if (result.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    var refreshed = await RefreshTokenAsync();

                    if (refreshed)
                    {
                        // 重试原始请求
                        result = await operation();

                        if (result.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                        {
                            // 刷新后仍然401，跳转到登录页
                            await NavigateToLogin();
                        }
                    }
                    else
                    {
                        // 刷新失败，跳转到登录页
                        await NavigateToLogin();
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                // 对于其他异常，返回错误响应
                var errorResponse = new BaseResponse
                {
                    IsSuccess = false,
                    Message = ex.Message,
                    StatusCode = System.Net.HttpStatusCode.InternalServerError
                };
                return errorResponse;
            }
        }

        private async Task<bool> RefreshTokenAsync()
        {
            // 避免多个请求同时刷新
            await _refreshSemaphore.WaitAsync();
            try
            {
                if (_isRefreshing)
                {
                    // 如果已经在刷新，等待刷新完成
                    return !string.IsNullOrEmpty(_userSessionService.Token);
                }

                _isRefreshing = true;

                // 从本地存储获取RefreshToken
                var refreshToken = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "refreshToken");

                if (string.IsNullOrEmpty(refreshToken))
                {
                    return false;
                }

                // 调用刷新API
                var refreshRequest = new RefreshTokenRequest { RefreshToken = refreshToken };
                var json = JsonSerializer.Serialize(refreshRequest);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                // 不使用AddJwtHeader，因为refresh token请求不需要Bearer token
                _httpClient.DefaultRequestHeaders.Authorization = null;

                var response = await _httpClient.PostAsync("/auth/refresh-token", content);

                if (response.IsSuccessStatusCode)
                {
                    var responseJson = await response.Content.ReadAsStringAsync();
                    var tokenResponse = JsonSerializer.Deserialize<SignInResponse>(responseJson,
                        new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                    if (tokenResponse != null)
                    {
                        // 更新本地存储
                        await _jsRuntime.InvokeVoidAsync("localStorage.setItem", "authToken", tokenResponse.Token);

                        if (!string.IsNullOrEmpty(tokenResponse.RefreshToken))
                        {
                            await _jsRuntime.InvokeVoidAsync("localStorage.setItem", "refreshToken", tokenResponse.RefreshToken);
                        }

                        // 更新用户会话
                        _userSessionService.SetSession(tokenResponse.UserName, tokenResponse.Token, tokenResponse.Role, tokenResponse.OrgId);

                        return true;
                    }
                }

                return false;
            }
            finally
            {
                _isRefreshing = false;
                _refreshSemaphore.Release();
            }
        }

        private async Task NavigateToLogin()
        {
            // 清理本地存储
            await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", "authToken");
            await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", "refreshToken");
            await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", "authUser");

            // 清理会话
            _userSessionService.ClearSession();

            // 导航到登录页
            var returnUrl = Uri.EscapeDataString(_navigationManager.Uri);
            _navigationManager.NavigateTo($"/user/login?returnUrl={returnUrl}", forceLoad: true);
        }

        private async Task<BaseResponse<T>> GetResponse<T>(HttpResponseMessage response)
        {
            var json = await response.Content.ReadAsStringAsync();
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

        private async Task<BaseResponse> GetResponse(HttpResponseMessage response)
        {
            var json = await response.Content.ReadAsStringAsync();
            var result = new BaseResponse();
            result.IsSuccess = response.IsSuccessStatusCode;
            result.StatusCode = response.StatusCode;
            result.Message = response.ReasonPhrase;
            return result;
        }
    }
}