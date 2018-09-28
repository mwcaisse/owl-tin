using System;
using System.Collections.Generic;
using System.Text;
using Sodium;

namespace Mitchell.Authentication.PasswordHasher
{
    public class ArgonPasswordHasher : IPasswordHasher
    {
        public string HashPassword(string password)
        {
            return PasswordHash.ArgonHashString(password, PasswordHash.StrengthArgon.Moderate);
        }

        public bool VerifyPassword(string hash, string password)
        {
            return PasswordHash.ArgonHashStringVerify(hash, password);
        }
    }
}
