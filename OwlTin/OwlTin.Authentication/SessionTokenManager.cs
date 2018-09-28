using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication;

namespace OwlTin.Authentication
{
    public class SessionTokenManager
    {

        private readonly Dictionary<string, ISessionToken> _tokens;

        public SessionTokenManager()
        {
            _tokens = new Dictionary<string, ISessionToken>();
        }

        public ISessionToken Get(string id)
        {
            if (_tokens.ContainsKey(id))
            {
                var token = _tokens[id];
                if (!IsTokenValid(token))
                {
                    token = null;
                }
                return token;
            }
            return null;
        }

        private bool IsTokenValid(ISessionToken token)
        {
            if (null != token && token.Expired)
            {
                _tokens.Remove(token.Id);
                return false;
            }
            return null != token;
        }

        public ISessionToken GetTokenForUser(string username)
        {
            var userTokens = _tokens.Where(kv => kv.Value.Username == username && !kv.Value.Expired)
                .ToList();

            if (userTokens.Any())
            {
                return userTokens.First().Value;
            }
            return null;
        }

        public ISessionToken CreateToken(string username, ClaimsPrincipal principal)
        {
            var token = new SessionToken(CreateTokenId(), username, CreateAuthenticationTicket(principal),
                CreateExpirationDate());
            _tokens.Add(token.Id, token);
            return token;
        }

        private AuthenticationTicket CreateAuthenticationTicket(ClaimsPrincipal principal)
        {
            return new AuthenticationTicket(principal, TokenAuthenticationOptions.AuthenticationScheme);
        }

        private string CreateTokenId()
        {
            return Guid.NewGuid().ToString();
        }

        private DateTime CreateExpirationDate()
        {
            return DateTime.Now.AddHours(1);
        }
    }
}
