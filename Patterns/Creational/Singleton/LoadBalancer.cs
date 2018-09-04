using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Creational.Singleton
{
    public class LoadBalancer
    {
        private static LoadBalancer _instance;

        private List<string> _servers = new List<string>();

        private static object _lockObject = new object();

        private Random _random = new Random();

        protected LoadBalancer()
        {
            _servers.Add("Server1");
            _servers.Add("Server2");
            _servers.Add("Server3");
            _servers.Add("Server4");
            _servers.Add("Server5");
        }

        public static LoadBalancer GetLoadBalancer()
        {
            if (_instance == null)
            {
                lock (_lockObject)
                {
                    if (_instance == null)
                        _instance = new LoadBalancer();

                }
            }

            return _instance;
        }

        public string Server
        {
            get
            {
                int r = _random.Next(_servers.Count);
                return _servers[r];
            }
        }
    }
}
