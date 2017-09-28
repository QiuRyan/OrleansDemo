using System;
using Orleans.Runtime.Host;

namespace Server
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (SiloHost host = new SiloHost("Default"))
            {
                host.LoadOrleansConfig();
                host.InitializeOrleansSilo();
                host.StartOrleansSilo();

                Console.WriteLine("Silo 启动成功......");
                Console.ReadLine();

                host.StopOrleansSilo();
            }
        }
    }
}