using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Demo.Lib;
using Orleans;

namespace Demo.Interface
{
    public interface IUser : IGrainWithGuidKey
    {
        Task<List<UserInfo>> GetAllUser();

        Task<UserInfo> GetCurrentUser(Guid userid);

        Task<UserInfo> GetUserByCellphone(string cellphone);

        Task<UserInfo> GetUserById(string userid);

        Task<UserInfo> UpdateUserCellphoneById(UserInfo userInfo);
    }
}