using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Lib
{
    public class DBHelper
    {

        //private static string conn = "Server=tcp:biz.db.dev.ad.jinyinmao.com.cn,1433;Database=jym-biz;User ID=db-user-front;Password=0SmDXp8i7MRfg29HJk1N
        private static string conn = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString; 
        public static async Task<List<UserInfo>> GetUsers()
        {
            using (var db = new DemoDb(conn))
            {
                return await db.User.Take(10).ToListAsync();
            }
        }
        public static async Task<UserInfo> GetUserById(string userid)
        {
            using (var db = new DemoDb(conn))
            {
                return await db.User.FirstOrDefaultAsync(u => u.UserIdentifier == userid);
            }
        }
        public static async Task<UserInfo> GetUserByCellphone(string cellphone)
        {
            using (var db = new DemoDb(conn))
            {
                return await db.User.FirstOrDefaultAsync(u => u.Cellphone == cellphone);
            }
        }
        public static async Task<UserInfo> GetUserByUserId(string userid)
        {
            using (var db = new DemoDb(conn))
            {
                return await db.Database.SqlQuery<UserInfo>($"SELECT* FROM Users u WHERE u.UserIdentifier='{userid}';").FirstOrDefaultAsync();
            }
        }
    }
}
