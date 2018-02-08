using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rest
{
    public class Repository
    {
        private volatile static Repository instance;
        private static object lockingObject = new object();

        private Repository()
        {
        }
        public static Repository Get()
        {
            if (instance == null)
            {
                lock (lockingObject)
                {
                    if (instance == null)
                    {
                        instance = new Repository();
                    }
                }
            }
            return instance;
        }

        public string UrlGutHub()
        {
            return "https://api.github.com/orgs/dotnet/repos";
        }

        public string MediaTypeHeaderValue()
        {
            return "application/vnd.github.v3+json";
        }
    }
}