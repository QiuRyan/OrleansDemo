using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Lib;
using Orleans;

namespace Demo.Interface
{
    public interface IUser : IGrainWithGuidKey
    {
        Task<UserInfo> GetCurrentUser(Guid userid);
        Task<List<UserInfo>> GetAllUser();
        Task<UserInfo> GetUserByCellphone(string cellphone);
        Task<UserInfo> GetUserById(string userid);
    }

}
