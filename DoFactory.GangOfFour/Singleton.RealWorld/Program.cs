using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton.RealWorld
{
    class Program
    {
        static void Main()
        {
            LoadBalancer b1 = LoadBalancer.GetLoadBalancer();
            LoadBalancer b2 = LoadBalancer.GetLoadBalancer();
            LoadBalancer b3 = LoadBalancer.GetLoadBalancer();
            LoadBalancer b4 = LoadBalancer.GetLoadBalancer();

            if (b1 == b2 && b2 == b3 && b3 == b4)
            {
                Console.WriteLine("Same instance\n");
            }

            LoadBalancer balancer = LoadBalancer.GetLoadBalancer();
            for (int i = 0; i < 15; i++)
            {
                string server = balancer.Server;
                Console.WriteLine("Dispatch Request to: " + server);
            }

            Console.ReadKey();
        }
    }

    class LoadBalancer
    {
        private static LoadBalancer _instance;
        private List<string> _servers = new List<string>();
        private Random _random = new Random();
        private static object syncLock = new object();

        protected LoadBalancer()
        {
            _servers.Add("ServerI");
            _servers.Add("ServerII");
            _servers.Add("ServerII");
            _servers.Add("ServerIV");
            _servers.Add("ServerV");
        }

        public static LoadBalancer GetLoadBalancer()
        {
            if (_instance == null)
            {
                lock (syncLock)
                {
                    if (_instance == null)
                    {
                        _instance = new LoadBalancer();
                    }
                }
            }

            return _instance;
        }

        public string Server
        {
            get
            {
                int r = _random.Next(_servers.Count);
                return _servers[r].ToString();
            }
        }
    }
}
