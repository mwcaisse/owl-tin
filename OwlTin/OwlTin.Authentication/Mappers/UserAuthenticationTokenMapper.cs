using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OwlTin.Authentication.Entities;
using OwlTin.Authentication.ViewModels;
using OwlTin.Common.ViewModels;

namespace OwlTin.Authentication.Mappers
{
    public static class UserAuthenticationTokenMapper
    {

        public static UserAuthenticationTokenViewModel ToViewModel(this UserAuthenticationToken token)
        {
            var vm = new UserAuthenticationTokenViewModel()
            {
                Active = token.Active,
                ExpirationDate = token.ExpirationDate,
                Description = token.Description,
                UserId = token.UserId,
                UserAuthenticationTokenId = token.UserAuthenticationTokenId,
                LastLogin = token.LastLogin,
                LastLoginAddress = token.LastLoginAddress,
                CreateDate = token.CreateDate
            };
            return vm;
        }

        public static IEnumerable<UserAuthenticationTokenViewModel> ToViewModel(this
            IEnumerable<UserAuthenticationToken> tokens)
        {
            return tokens.Select(x => x.ToViewModel());
        }

        public static PagedViewModel<UserAuthenticationTokenViewModel> ToViewModel(this
            PagedViewModel<UserAuthenticationToken> pagedTokens)
        {
            return new PagedViewModel<UserAuthenticationTokenViewModel>()
            {
                Take = pagedTokens.Take,
                Skip = pagedTokens.Skip,
                Data = pagedTokens.Data.ToViewModel(),
                Total = pagedTokens.Total
            };
        }

    }
}
