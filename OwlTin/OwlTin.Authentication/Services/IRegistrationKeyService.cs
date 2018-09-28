using System;
using System.Collections.Generic;
using System.Text;
using OwlTin.Authentication.Entities;
using OwlTin.Authentication.ViewModels;
using OwlTin.Common.ViewModels;

namespace OwlTin.Authentication.Services
{
    public interface IRegistrationKeyService
    {
        UserRegistrationKey Get(long id);

        UserRegistrationKey Get(string key);

        PagedViewModel<UserRegistrationKey> GetAll(int skip, int take, SortParam sort);

        bool IsValid(string key);

        bool UseKey(string keyValue, User user);

        UserRegistrationKey Create(UserRegistrationKeyViewModel model);

        UserRegistrationKey Update(UserRegistrationKeyViewModel model);
    }
}
