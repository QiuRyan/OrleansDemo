using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Demo.Interface;
using Demo.Lib;
using Orleans;
using System.Configuration;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            GrainClient.Initialize();

            while (true)
            { 
                Console.Write("请输入用户的手机号：");
                var mobileNumber = Console.ReadLine();
                var userService = GrainClient.GrainFactory.GetGrain<IUser>(Guid.NewGuid());
                string userId = userService.GetUserByCellphone(mobileNumber).Result?.UserIdentifier;
                Console.WriteLine($"UserIdentifier:{userId},Cellphone:{mobileNumber}");

                Console.ReadKey();

                Console.WriteLine("Userinfo");
                Console.WriteLine("UserIdentifier                                         Cellphone");
                Console.WriteLine("----------------------------------------------------");
                List<UserInfo> users = userService.GetAllUser().Result;
                foreach (UserInfo userInfo in users)
                {
                    Console.WriteLine($"{userInfo.UserIdentifier}  | {userInfo.Cellphone}");
                }
                Console.WriteLine("----------------------------------------------------");

                Console.ReadKey();
            }
        }
    }
}
