using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart.Pages
{
    public class Application
    {
        private volatile static Application instance;
        private static object lockingObject = new object();

        private Application()
        {
        }

        public static Application Get()
        {
            if (instance == null)
            {
                lock (lockingObject)
                {
                    if (instance == null)
                    {
                        instance = new Application();
                    }
                }
            }
            return instance;
        }


    }
}
