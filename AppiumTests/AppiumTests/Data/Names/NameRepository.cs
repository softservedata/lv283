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
                .SetName("Barry")
                .Build()
            );

            result.Add(
                Name.Get()
                .SetName("Chuck")
                .Build()
            );

            result.Add(
                Name.Get()
                .SetName("David")
                .Build()
            );
            return result;
        }

        public List<IName> DogNames()
        {
            List<IName> result = new List<IName>();

            result.Add(
                Name.Get()
                .SetName("Ace")
                .Build()
            );

            result.Add(
                Name.Get()
                .SetName("Bandit")
                .Build()
            );

            result.Add(
                Name.Get()
                .SetName("Cha-Cha")
                .Build()
            );

            result.Add(
                Name.Get()
                .SetName("Deuce")
                .Build()
            );
            return result;
        }

        public List<IName> CatNames()
        {
            List<IName> result = new List<IName>();

            result.Add(
                Name.Get()
                .SetName("Fluffy")
                .Build()
            );

            result.Add(
                Name.Get()
                .SetName("Snuggles")
                .Build()
            );
            return result;
        }

        public List<IName> FishNames()
        {
            List<IName> result = new List<IName>();

            result.Add(
                Name.Get()
                .SetName("Goldy")
                .Build()
            );

            result.Add(
                Name.Get()
                .SetName("Bubbles")
                .Build()
            );
            return result;
        }
    }
}
