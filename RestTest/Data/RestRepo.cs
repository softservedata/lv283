using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace RestTest.Data
{
    class RestRepo
    {
        private volatile static RestRepo instance;
        private static object lockingObject = new object();

        private RestRepo()
        {
        }

        public static RestRepo Get()
        {
            if (instance == null)
            {
                lock (lockingObject)
                {
                    if (instance == null)
                    {
                        instance = new RestRepo();
                    }
                }
            }
            return instance;
        }

        public string UserAgentUrl()
        {
            return "http://httpbin.org/user-agent";
        }
    }
}
