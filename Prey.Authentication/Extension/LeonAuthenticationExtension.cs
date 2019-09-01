using Microsoft.AspNetCore.Builder;
using Prey.Authentication.Middleware;

namespace Prey.Authentication.Extension
{
    /// <summary>
    /// Leon 认证中间件扩展
    /// </summary>
    public static class LeonAuthenticationExtension
    {
        /// <summary>
        /// 应用 Leon 认证到 HTTP 请求管道
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseLeonAuthentication(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LeonAuthenticationMiddleware>();
        }
    }
}
