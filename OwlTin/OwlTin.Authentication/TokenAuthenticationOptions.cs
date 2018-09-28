using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;

namespace Mitchell.Authentication
{
    public class TokenAuthenticationOptions : AuthenticationSchemeOptions
    {

        public const string AuthenticationScheme = "AUTHENTICATION_SCHEME_SESSION_TOKEN";

        public const string SessionTokenHeader = "MITCHELL_SESSION";

        /// <summary>
        /// Determines if this request should be processed with Token Authentication
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static bool IsRequestCanidate(HttpContext context)
        {
            return context.Request.Headers.ContainsKey(TokenAuthenticationOptions.SessionTokenHeader);
        }

    }
}
