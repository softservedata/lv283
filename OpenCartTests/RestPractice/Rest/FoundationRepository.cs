using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestPractice.Rest
{
    class FoundationRepository
    {
        private volatile static FoundationRepository instance;
        private static object lockingObject = new object();

        private FoundationRepository()
        {
        }
        public static FoundationRepository Get()
        {
            if (instance == null)
            {
                lock (lockingObject)
                {
                    if (instance == null)
                    {
                        instance = new FoundationRepository();
                    }
                }
            }
            return instance;
        }

        public string UrlGutHub()
        {
            return "http://httpbin.org/";
        }

        public string MediaTypeHeaderValue()
        {
            return "application/vnd.github.v3+json";
        }

        public Dictionary<string, string> RequestHeaders()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            result.Add("User-Agent", ".NET Foundation Repository Reporter");
            return result;
        }
    }
}
