using OldHome.API.Services;
using OldHome.DesktopApp.Services;
using OldHome.DTO;
using OldHome.DTO.Base;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace OldHome.DesktopApp.Services
{
    public class ApiClient : IApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly Func<Task<SignInResponse?>>? _refreshTokenFunc;
        private readonly IUserSessionService _userSessionService;

        public ApiClient(HttpClient httpClient, Func<Task<SignInResponse?>>? refreshTokenFunc = null)
        {
            _httpClient = httpClient;
            _refreshTokenFunc = refreshTokenFunc;
            _userSessionService = ContainerLocator.Container.Resolve<IUserSessionService>();
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
            AddJwtHeader();
            try
            {
                var response = await _httpClient.GetAsync(url);
                return await HandleResponse(response, () => GetAsync<T>(url));
            }
            catch (Exception ex)
            {
                return new BaseResponse<T>
                {
                    IsSuccess = false,
                    Message = ex.Message,
                    StatusCode = System.Net.HttpStatusCode.InternalServerError
                };
            }
        }

        public async Task<BaseResponse<T>?> PostAsync<TRequest, T>(string url, TRequest request)
        {
            AddJwtHeader();
            string json = JsonSerializer.Serialize(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            try
            {
                var response = await _httpClient.PostAsync(url, content);
                return await HandleResponse(response, () => PostAsync<TRequest, T>(url, request));
            }
            catch (Exception ex)
            {
                return new BaseResponse<T>
                {
                    IsSuccess = false,
                    Message = ex.Message,
                    StatusCode = System.Net.HttpStatusCode.InternalServerError
                };
            }
        }

        private async Task<BaseResponse<T>?> HandleResponse<T>(HttpResponseMessage response, Func<Task<BaseResponse<T>?>> retryFunc)
        {
            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized && _refreshTokenFunc != null)
            {
                var res = await _refreshTokenFunc.Invoke();
                _userSessionService.SetSession(res.UserName, res.Token, res.Role, res.OrgId);
                if (!string.IsNullOrEmpty(_userSessionService.Token))
                    return await retryFunc();

                throw new UnauthorizedAccessException("Token 过期且刷新失败。");
            }

            try
            {
                var result = GetResponse<T>(response);
                if (!result.IsSuccess)
                    throw new HttpRequestException($"HTTP {result.StatusCode}:\n{result.Message}");
                return result;
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                throw;
            }
        }

        private async Task<BaseResponse?> HandleResponse(HttpResponseMessage response, Func<Task<BaseResponse?>> retryFunc)
        {
            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized && _refreshTokenFunc != null)
            {
                var res = await _refreshTokenFunc.Invoke();
                _userSessionService.SetSession(res.UserName, res.Token, res.Role, res.OrgId);
                if (!string.IsNullOrEmpty(_userSessionService.Token))
                    return await retryFunc();

                throw new UnauthorizedAccessException("Token 过期且刷新失败。");
            }

            try
            {
                var result = GetResponse(response);
                if (!result.IsSuccess)
                    throw new HttpRequestException($"HTTP {result.StatusCode}:\n{result.Message}");
                return result;
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                throw;
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

        public async Task<BaseResponse?> GetAsync(string url)
        {
            AddJwtHeader();
            try
            {
                var response = await _httpClient.GetAsync(url);
                return await HandleResponse(response, () => GetAsync(url));
            }
            catch (Exception ex)
            {
                return new BaseResponse
                {
                    IsSuccess = false,
                    Message = ex.Message,
                    StatusCode = System.Net.HttpStatusCode.InternalServerError
                };
            }
        }

        public async Task<BaseResponse?> PostAsync<TRequest>(string url, TRequest request)
        {
            AddJwtHeader();
            string json = JsonSerializer.Serialize(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            try
            {
                var response = await _httpClient.PostAsync(url, content);
                return await HandleResponse(response, () => PostAsync<TRequest>(url, request));
            }
            catch (Exception ex)
            {
                return new BaseResponse
                {
                    IsSuccess = false,
                    Message = ex.Message,
                    StatusCode = System.Net.HttpStatusCode.InternalServerError
                };
            }
        }
    }
}
