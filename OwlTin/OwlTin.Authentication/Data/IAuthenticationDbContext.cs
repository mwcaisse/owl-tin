using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using OwlTin.Authentication.Entities;

namespace OwlTin.Authentication.Data
{
    public interface IAuthenticationDbContext
    {
        DbSet<User> Users { get; }

        DbSet<UserAuthenticationToken> UserAuthenticationTokens { get; }

        DbSet<UserRegistrationKey> UserRegistrationKeys { get; }

        DbSet<UserRegistrationKeyUse> UserRegistrationKeyUses { get; }

        int SaveChanges();
    }
}
