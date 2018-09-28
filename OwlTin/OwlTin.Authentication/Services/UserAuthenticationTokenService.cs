using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OwlTin.Authentication.Data;
using OwlTin.Authentication.Entities;
using OwlTin.Authentication.Models;
using OwlTin.Authentication.PasswordHasher;
using OwlTin.Common;
using OwlTin.Common.Exceptions;
using OwlTin.Common.ViewModels;

namespace OwlTin.Authentication.Services
{
    public class UserAuthenticationTokenService : IUserAuthenticationTokenService
    {

        private readonly IAuthenticationDbContext _db;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IRequestInformation _requestInformation;

        public UserAuthenticationTokenService(IAuthenticationDbContext db, IPasswordHasher passwordHasher,
            IRequestInformation requestInformation)
        {
            this._db = db;
            this._passwordHasher = passwordHasher;
            this._requestInformation = requestInformation;
        }

        public UserAuthenticationToken Get(long id)
        {
            return _db.UserAuthenticationTokens.FirstOrDefault(ut => ut.UserAuthenticationTokenId == id);
        }

        public IEnumerable<UserAuthenticationToken> GetActive(long userId)
        {
            return _db.UserAuthenticationTokens.Active().Where(ut => ut.UserId == userId).ToList();
        }

        public PagedViewModel<UserAuthenticationToken> GetActiveForUser(int skip, int take, SortParam sort)
        {
            return _db.UserAuthenticationTokens
                .Active()
                .Where(ut => ut.UserId == _requestInformation.UserId)
                .PageAndSort(skip, take, sort);
        }

        public string CreateToken(string description)
        {

            var user = _db.Users.Active().FirstOrDefault(u => u.UserId == _requestInformation.UserId);
            if (null == user)
            {
                throw new EntityValidationException("Cannot create Authentication Token. User does not exist.");
            }
            if (string.IsNullOrWhiteSpace(description))
            {
                throw new EntityValidationException("Cannot create Authentication Token. Description cannot be null.");
            }

            var token = CreateRandomTokenValue();
            var authToken = new UserAuthenticationToken()
            {
                User = user,
                Active = true,
                Description = description,
                Token = _passwordHasher.HashPassword(token)
            };
            _db.UserAuthenticationTokens.Add(authToken);
            _db.SaveChanges();

            return token;
        }

        private string CreateRandomTokenValue()
        {
            return Guid.NewGuid().ToString();
        }

        public UserAuthenticationToken RecordUserLogin(UserAuthenticationToken token)
        {
            var toUpdate = _db.UserAuthenticationTokens
                .FirstOrDefault(t => t.UserAuthenticationTokenId == token.UserAuthenticationTokenId);
            if (null == toUpdate)
            {
                throw new EntityValidationException("No User Authentication Token with the given id eixsts.");
            }

            toUpdate.LastLogin = DateTime.Now;
            toUpdate.LastLoginAddress = _requestInformation.ClientAddress;

            _db.SaveChanges();

            return toUpdate;
        }

        public UserAuthenticationToken Update(UserAuthenticationToken token)
        {
            var toUpdate = _db.UserAuthenticationTokens
                .FirstOrDefault(t => t.UserAuthenticationTokenId == token.UserAuthenticationTokenId);
            if (null == toUpdate)
            {
                throw new EntityValidationException("No User Authentication Token with the given id eixsts.");
            }

            toUpdate.Active = token.Active;

            _db.SaveChanges();
            return token;
        }

        public bool DeleteToken(long id)
        {
            var token = Get(id);
            if (token.UserId != _requestInformation.UserId)
            {
                throw new EntityValidationException("You do not have permission to delete this token!");
            }

            token.Active = false;
            _db.SaveChanges();
            return true;
        }
    }
}
