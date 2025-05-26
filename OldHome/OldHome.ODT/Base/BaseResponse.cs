using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.DTO.Base
{
    public class BaseResponse
    {
        public bool IsSuccess { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string? Message { get; set; }

        public void CallbackAction(Action<BaseResponse> successAction, Action<BaseResponse>? failAction = null)
        {
            if (this.IsSuccess)
            {
                successAction(this);
            }
            else
            {
                if (failAction != null)
                {
                    failAction(this);
                }
                else
                {
                    throw new Exception($"响应代码:{this.StatusCode},请求失败: {this.Message}");
                }
            }
        }
    }

    public class BaseResponse<T>
    {
        public bool IsSuccess { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }

        public void CallbackAction(Action<BaseResponse<T>> successAction, Action<BaseResponse<T>>? failAction = null)
        {
            if (this.IsSuccess)
            {
                successAction(this);
            }
            else
            {
                if (failAction != null)
                {
                    failAction(this);
                }
                else
                {
                    throw new Exception($"响应代码:{this.StatusCode},请求失败: {this.Message}");
                }
            }

        }

        public static BaseResponse<T> Success(T data, string message = "成功", HttpStatusCode code = HttpStatusCode.OK)
        {
            return new BaseResponse<T>
            {
                StatusCode = code,
                Message = message,
                Data = data
            };
        }

        public static BaseResponse<T> Fail(string message = "失败", HttpStatusCode code = HttpStatusCode.BadRequest)
        {
            return new BaseResponse<T>
            {
                StatusCode = code,
                Message = message,
                Data = default
            };
        }
    }
}
