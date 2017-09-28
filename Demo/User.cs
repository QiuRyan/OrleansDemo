// *********************************************************************** Assembly : Demo Author :
// qiu.yanjun Created : 09-25-2017
//
// Last Modified By : qiu.yanjun Last Modified On : 09-26-2017
// ***********************************************************************
// <copyright file="User.cs" company="">Copyright © 2017</copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Demo.Interface;
using Demo.Lib;
using Orleans.Providers;

namespace Demo
{
    /// <summary>Class User.</summary>
    /// <seealso cref="UserState"/>
    /// <seealso cref="Demo.Interface.IUser"/>
    [StorageProvider(ProviderName = "SqlServer")]
    public class User : BaseGrain<UserState>, IUser
    {
        /// <summary>Gets all user.</summary>
        /// <returns>Task&lt;List&lt;UserInfo&gt;&gt;.</returns>
        public async Task<List<UserInfo>> GetAllUser()
        {
            return await DBHelper.GetUsers();
        }

        /// <summary>Gets the current user.</summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>Task&lt;UserInfo&gt;.</returns>
        public async Task<UserInfo> GetCurrentUser(Guid userId)
        {
            return await DBHelper.GetUserById(userId.ToString("N"));
        }

        /// <summary>Gets the user by cellphone.</summary>
        /// <param name="cellphone">The cellphone.</param>
        /// <returns>Task&lt;UserInfo&gt;.</returns>
        public async Task<UserInfo> GetUserByCellphone(string cellphone)
        {
            return await DBHelper.GetUserByCellphone(cellphone);
        }

        /// <summary>Gets the user by identifier.</summary>
        /// <param name="userid">The userid.</param>
        /// <returns>Task&lt;UserInfo&gt;.</returns>
        public async Task<UserInfo> GetUserById(string userid)
        {
            return await DBHelper.GetUserByUserId(userid);
        }

        public async Task<UserInfo> UpdateUserCellphoneById(UserInfo userInfo)
        {
            return await DBHelper.UpdateUserCellphoneById(userInfo);
        }
    }
}