using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Authentication;

namespace OwlTin.Authentication
{
    public class SessionToken : ISessionToken
    {
        public string Id { get; private set; }
        public string Username { get; private set; }
        public AuthenticationTicket Ticket { get; private set; }

        public bool Expired => DateTime.Now.CompareTo(ExpirationDate) >= 0;

        private DateTime CreateDate { get; }
        private DateTime ExpirationDate { get; }

        public SessionToken(string id, string username, AuthenticationTicket ticket, DateTime expirationDate)
        {
            Id = id;
            Username = username;
            Ticket = ticket;
            CreateDate = DateTime.Now;
            ExpirationDate = expirationDate;
        }


    }
}
