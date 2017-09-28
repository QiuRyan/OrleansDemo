// *********************************************************************** Assembly : Demo.Lib Author
// : qiu.yanjun Created : 09-26-2017
//
// Last Modified By : qiu.yanjun Last Modified On : 09-26-2017
// ***********************************************************************
// <copyright file="DBHelper.cs" company="">Copyright © 2017</copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Lib
{
    /// <summary>Class DBHelper.</summary>
    public class DBHelper
    {
        //private static string conn = "Server=tcp:biz.db.dev.ad.jinyinmao.com.cn,1433;Database=jym-biz;User ID=db-user-front;Password=0SmDXp8i7MRfg29HJk1N
        /// <summary>The connection</summary>
        private static readonly string conn = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;

        /// <summary>Gets the user by cellphone.</summary>
        /// <param name="cellphone">The cellphone.</param>
        /// <returns>Task&lt;UserInfo&gt;.</returns>
        public static async Task<UserInfo> GetUserByCellphone(string cellphone)
        {
            using (DemoDb db = new DemoDb(conn))
            {
                return await db.User.FirstOrDefaultAsync(u => u.Cellphone == cellphone);
            }
        }

        /// <summary>Gets the user by identifier.</summary>
        /// <param name="userid">The userid.</param>
        /// <returns>Task&lt;UserInfo&gt;.</returns>
        public static async Task<UserInfo> GetUserById(string userid)
        {
            using (DemoDb db = new DemoDb(conn))
            {
                return await db.User.FirstOrDefaultAsync(u => u.UserIdentifier == userid);
            }
        }

        /// <summary>Gets the user by user identifier.</summary>
        /// <param name="userid">The userid.</param>
        /// <returns>Task&lt;UserInfo&gt;.</returns>
        public static async Task<UserInfo> GetUserByUserId(string userid)
        {
            using (DemoDb db = new DemoDb(conn))
            {
                return await db.Database.SqlQuery<UserInfo>($"SELECT* FROM Users u WHERE u.UserIdentifier='{userid}';").FirstOrDefaultAsync();
            }
        }

        /// <summary>Gets the users.</summary>
        /// <returns>Task&lt;List&lt;UserInfo&gt;&gt;.</returns>
        public static async Task<List<UserInfo>> GetUsers()
        {
            using (DemoDb db = new DemoDb(conn))
            {
                return await db.User.Take(10).ToListAsync();
            }
        }

        public static async Task<UserInfo> UpdateUserCellphoneById(UserInfo userInfo)
        {
            using (DemoDb db = new DemoDb(conn))
            {
                UserInfo user = await db.User.FirstOrDefaultAsync(u => u.UserIdentifier == userInfo.UserIdentifier);

                if (user == null)
                {
                    return null;
                }
                user.Cellphone = userInfo.Cellphone;
                await db.SaveChangesAsync();
                return userInfo;
            }
        }
    }
}