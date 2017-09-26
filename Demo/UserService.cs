using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Interface;
using Demo.Lib;
using Orleans;

namespace Demo
{
    public class UserService : Grain, IUser
    {
        public async Task<UserInfo> GetCurrentUser(Guid userId)
        {
            return await DBHelper.GetUserById(userId.ToString("N")); 
        }
        public async Task<List<UserInfo>> GetAllUser()
        {
            return await DBHelper.GetUsers(); 
        }

        public async Task<UserInfo> GetUserByCellphone(String cellphone)
        {
            return await DBHelper.GetUserByCellphone(cellphone); 
        }

        public async Task<UserInfo> GetUserById(string userid)
        {
            return await DBHelper.GetUserByUserId(userid);
        }
    }
}
