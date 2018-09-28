using System;
using System.Collections.Generic;
using System.Text;
using Mitchell.Authentication.Entities;
using Mitchell.Common.ViewModels;

namespace Mitchell.Authentication.Services
{
    public interface IUserAuthenticationTokenService
    {
        /// <summary>
        /// Fetches the User Authentication Token with the given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        UserAuthenticationToken Get(long id);

        /// <summary>
        ///  Fetches the active User Authentication Tokens for the given user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        IEnumerable<UserAuthenticationToken> GetActive(long userId);
        
        /// <summary>
        /// Fetches Active tokens for the given user
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <param name="sort"></param>
        /// <returns></returns>
        PagedViewModel<UserAuthenticationToken> GetActiveForUser(int skip, int take,
            SortParam sort);

        /// <summary>
        /// Creates a token for the given user with the given description
        /// </summary>
        /// <param name="description"></param>
        /// <returns></returns>
        string CreateToken(string description);

        /// <summary>
        /// Updates the given User Authentication Token
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        UserAuthenticationToken Update(UserAuthenticationToken token);

        /// <summary>
        /// Deletes the given authentication token
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DeleteToken(long id);

        /// <summary>
        /// Records a log in using the given authentication token
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        UserAuthenticationToken RecordUserLogin(UserAuthenticationToken token);
    }
}
