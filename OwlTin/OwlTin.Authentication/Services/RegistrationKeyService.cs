using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Mitchell.Authentication.Data;
using Mitchell.Authentication.Entities;
using Mitchell.Authentication.ViewModels;
using Mitchell.Common;
using Mitchell.Common.Exceptions;
using Mitchell.Common.ViewModels;

namespace Mitchell.Authentication.Services
{
    public class RegistrationKeyService : IRegistrationKeyService
    {

        private readonly IAuthenticationDbContext _db;

        public RegistrationKeyService(IAuthenticationDbContext db)
        {
            this._db = db;
        }

        protected IQueryable<UserRegistrationKey> GetRegistrationKeysIncluding()
        {
            return _db.UserRegistrationKeys.Include(u => u.UserRegistrationKeyUses)
                .ThenInclude(ku => ku.User);
        }

        public UserRegistrationKey Get(long id)
        {
            return GetRegistrationKeysIncluding().FirstOrDefault(x => x.UserRegistrationKeyId == id);
        }

        public UserRegistrationKey Get(string key)
        {
            return GetRegistrationKeysIncluding().FirstOrDefault(x => x.Key == key);
        }

        public PagedViewModel<UserRegistrationKey> GetAll(int skip, int take, SortParam sort)
        {
            return GetRegistrationKeysIncluding().PageAndSort(skip, take, sort);
        }

        public bool IsValid(string key)
        {
            var regKey = Get(key);
            if (null != regKey)
            {
                return regKey.Active && regKey.UsesRemaining > 0;
            }
            return false;
        }

        public bool UseKey(string keyValue, User user)
        {
            if (!IsValid(keyValue))
            {
                return false;
            }
            var key = Get(keyValue);

            key.UsesRemaining--;

            key.UserRegistrationKeyUses.Add(new UserRegistrationKeyUse()
            {
                User = user,
                UserRegistrationKey = key
            });

            _db.SaveChanges();
            return true;
        }

        public UserRegistrationKey Create(UserRegistrationKeyViewModel model)
        {
            if (null != Get(model.Key))
            {
                throw new EntityValidationException("A registration key with the given value already exists.");
            }

            var toCreate = new UserRegistrationKey()
            {
                UsesRemaining = model.UsesRemaining,
                Active = model.Active,
                Key = model.Key
            };

            _db.UserRegistrationKeys.Add(toCreate);
            _db.SaveChanges();

            return Get(toCreate.UserRegistrationKeyId);
        }

        public UserRegistrationKey Update(UserRegistrationKeyViewModel model)
        {
            var toUpdate = Get(model.UserRegistrationKeyId);

            if (null == toUpdate)
            {
                throw new EntityValidationException("No registration key with that ID exists!");
            }
            if (!string.Equals(toUpdate.Key, model.Key, StringComparison.CurrentCultureIgnoreCase))
            {
                throw new EntityValidationException("You cannot changed the key value!");
            }

            toUpdate.Active = model.Active;
            toUpdate.UsesRemaining = model.UsesRemaining;

            return Get(toUpdate.UserRegistrationKeyId);
        }
    }
}
