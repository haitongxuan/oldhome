using OldHome.DTO.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.DesktopApp.Services
{
    public interface IApiClient
    {
        Task<BaseResponse<T>?> GetAsync<T>(string url);
        Task<BaseResponse<T>?> PostAsync<TRequest, T>(string url, TRequest request);

        Task<BaseResponse?> GetAsync(string url);
        Task<BaseResponse?> PostAsync<TRequest>(string url, TRequest request);
    }
}
