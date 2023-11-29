using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyExercise.Classes
{
    public class SingletonProxy
    {
        private static SingletonProxy instance;
        private List<string> serversIP;
        private SingletonProxy() {
            serversIP = new List<string>() {
                RandomIPGenerator(),
                RandomIPGenerator(),
                RandomIPGenerator(),
                RandomIPGenerator()
            };
        }    
        private string RandomIPGenerator()
        {
            Random gen=new Random();
            string address = $"{gen.Next(256)}.{gen.Next(256)}.{gen.Next(256)}.{gen.Next(256)}";
            return address;
        }

        public static SingletonProxy Instance
        {
            get
            {
                if (instance == null)
                    instance = new SingletonProxy();
                return instance;
            }
        }
        public string ServerRequest(int id) {
            return serversIP[id];
        }
    }
}

