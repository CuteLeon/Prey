using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Prey.Authentication.Middleware
{
    /// <summary>
    /// Leon 认证中间件
    /// </summary>
    public class LeonAuthenticationMiddleware
    {
        /// <summary>
        /// 下一 HTTP 请求委托
        /// </summary>
        private readonly RequestDelegate next;

        /// <summary>
        /// Initializes a new instance of the <see cref="LeonAuthenticationMiddleware"/> class.
        /// </summary>
        /// <param name="next"></param>
        public LeonAuthenticationMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        /// <summary>
        /// 调用
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public Task Invoke(HttpContext httpContext)
        {

            return this.next(httpContext);
        }
    }
}
