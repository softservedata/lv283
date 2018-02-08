using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestTests.Data.Rest
{
    public class RestRepository
    {
        private volatile static RestRepository instance;
        private static object lockingObject = new object();

        private RestRepository()
        {
        }

        public static RestRepository Get()
        {
            if (instance == null)
            {
                lock (lockingObject)
                {
                    if (instance == null)
                    {
                        instance = new RestRepository();
                    }
                }
            }
            return instance;
        }

        public string UrlHttpBin()
        {
            return "http://httpbin.org/ip";
        }

        public string MyIP()
        {
            return "188.230.55.18";
        }
    }
}
