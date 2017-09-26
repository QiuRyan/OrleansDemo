using System;
using Demo.Interface;
using Demo.Lib;
using Orleans;

namespace Client
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            GrainClient.Initialize();

            while (true)
            {
                Console.Write("请输入用户的手机号：");
                string cellPhone = Console.ReadLine();
                IUser user = GrainClient.GrainFactory.GetGrain<IUser>(Guid.NewGuid());
                string userId = user.GetUserByCellphone(cellPhone).Result?.UserIdentifier;
                Console.WriteLine($"UserIdentifier:{userId},Cellphone:{cellPhone}");

                Console.ReadKey();

                Console.Write("请输入新的手机号：");
                string newCellphone = Console.ReadLine();
                UserInfo userInfo = user.UpdateUserCellphoneById(new UserInfo { Cellphone = newCellphone, UserIdentifier = userId }).Result;

                if (userInfo == null)
                {
                    Console.Write("用户不存在,请输入正确的手机号");
                    return;
                }
                Console.WriteLine($"新用户信息:UserIdentifier:{userInfo.UserIdentifier},Cellphone:{userInfo.Cellphone}");

                Console.ReadKey();
            }
        }
    }
}