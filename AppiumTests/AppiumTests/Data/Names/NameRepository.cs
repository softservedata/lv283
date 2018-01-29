using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppiumTests.Data.Names
{
    class NameRepository
    {
        private volatile static NameRepository instance;
        private static object lockingObject = new object();

        private NameRepository()
        {

        }

        public static NameRepository Get()
        {
            if (instance == null)
            {
                lock (lockingObject)
                {
                    if (instance == null)
                    {
                        instance = new NameRepository();
                    }
                }
            }
            return instance;
        }

        /*public IName ValidNames()
        {
            return Name.Get()
                .SetName("123")
                .Build();
        }*/

        public List<IName> PeopleNames()
        {
            List<IName> result = new List<IName>();

            result.Add(
                Name.Get()
                .SetName("Arnold")
                .Build()
            );

            result.Add(
                Name.Get()
                .SetName("David")
                .Build()
            );
            return result;
        }
    }
}
