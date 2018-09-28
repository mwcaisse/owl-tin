using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Authentication;

namespace Mitchell.Authentication
{
    public interface ISessionToken
    {
        string Id { get; }
        string Username { get; }
        AuthenticationTicket Ticket { get; }
        bool Expired { get; }
    }
}
