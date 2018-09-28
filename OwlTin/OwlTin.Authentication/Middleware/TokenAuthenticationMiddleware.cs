using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Mitchell.Authentication.Middleware
{
    public class TokenAuthenticationMiddleware
    {

        private readonly RequestDelegate _next;

        public TokenAuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var scheme = CookieAuthenticationDefaults.AuthenticationScheme;
            if (TokenAuthenticationOptions.IsRequestCanidate(context))
            {
                scheme = TokenAuthenticationOptions.AuthenticationScheme;
            }
            var result = await context.AuthenticateAsync(scheme);
            if (result.Succeeded)
            {
                context.User = result.Principal;
            }
            await _next(context);
        }
    }

    public static class TokenAuthenticationMiddlewareExtensions
    {
        public static IApplicationBuilder UseTokenAuthentication(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TokenAuthenticationMiddleware>();
        }
    }
}
