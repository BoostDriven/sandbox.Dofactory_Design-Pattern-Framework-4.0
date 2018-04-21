using System;
using System.Collections.Generic;

namespace Singleton.NETOptimized
{
    class Program
    {
        static void Main()
        {
            var b1 = LoadBalancer.GetLoadBalancer();
            var b2 = LoadBalancer.GetLoadBalancer();
            var b3 = LoadBalancer.GetLoadBalancer();
            var b4 = LoadBalancer.GetLoadBalancer();

            // Confirm these are the same instance
            if (b1 == b2 && b2 == b3 && b3 == b4)
            {
                Console.WriteLine("Same instance\n");
            }

            var balancer = LoadBalancer.GetLoadBalancer();
            for (int i = 0; i < 15; i++)
            {
                string serverName = balancer.NextServer.Name;
                Console.WriteLine("Dispatch request to: "
                    + serverName);
            }

            // wait for user
            Console.ReadKey();
        }
    }

    sealed class LoadBalancer
    {
        private static readonly LoadBalancer _instance =
            new LoadBalancer();

        // type-safe generic list of servers
        private List<Server> _servers;
        private Random _random = new Random();

        // constructor
        private LoadBalancer()
        {
            _servers = new List<Server>
            {
                new NETOptimized.Server { Name = "ServerI", IP = "120.14.220.18" },
                new NETOptimized.Server { Name = "ServerII", IP = "120.14.220.19" },
                new NETOptimized.Server { Name = "ServerII", IP = "120.14.220.20" },
                new NETOptimized.Server { Name = "ServerIV", IP = "120.14.220.21" },
                new NETOptimized.Server { Name = "ServerV", IP = "120.14.220.22" }
            };
        }

        public static LoadBalancer GetLoadBalancer()
        {
            return _instance;
        }

        public Server NextServer
        {
            get
            {
                int r = _random.Next(_servers.Count);
                return _servers[r];
            }
        }
    }

    class Server
    {
        public string Name { get; set; }
        public string IP { get; set; }
    }
}
