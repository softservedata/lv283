using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestTest.Data
{
    public class FoundationRepository
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

        public string GetUrl(string url)
        {
            return url;
        }

        public string MediaTypeHeaderValue()
        {
            return "application/json";
        }
    }
}
