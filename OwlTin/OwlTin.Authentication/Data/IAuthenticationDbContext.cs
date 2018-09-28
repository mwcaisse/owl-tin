using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Mitchell.Authentication.Entities;

namespace Mitchell.Authentication.Data
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
