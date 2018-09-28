using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mitchell.Authentication.Entities;
using Mitchell.Authentication.ViewModels;

namespace Mitchell.Authentication.Mappers
{
    public static class UserMapper
    {

        public static UserViewModel ToViewModel(this User user)
        {
            if (null == user)
            {
                return null;
            }

            var vm = new UserViewModel()
            {
                Id = user.UserId,
                Username = user.Username,
                Name = user.Name
            };
            return vm;
        }

        public static IEnumerable<UserViewModel> ToViewModel(this IEnumerable<User> users)
        {
            return users.Select(u => u.ToViewModel());
        }

    }
}
