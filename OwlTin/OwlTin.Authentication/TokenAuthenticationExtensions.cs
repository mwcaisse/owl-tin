using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Authentication;

namespace OwlTin.Authentication
{
    public static class TokenAuthenticationExtensions
    {

        public static AuthenticationBuilder AddTokenAuthentication(this AuthenticationBuilder builder,
            Action<TokenAuthenticationOptions> configureOptions)
        {
            return builder.AddScheme<TokenAuthenticationOptions, TokenAuthenticationHandler>(
                TokenAuthenticationOptions.AuthenticationScheme, configureOptions);
        }
    }
}
