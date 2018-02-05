using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndroidTest.Data.Dates
{
    public class DateRepository
    {
        private volatile static DateRepository instance;
        private static object lockingObject = new object();

        private DateRepository() { }

        public static DateRepository Get()
        {
            if (instance == null)
            {
                lock (lockingObject)
                {
                    if (instance == null)
                    {
                        instance = new DateRepository();
                    }
                }
            }
            return instance;
        }

        public IDate ValentinesDay()
        {
            return Date.Get()
                .SetMonth(Month.February)
                .SetDay("14")
                .SetYear("2019")
                .Build();
        }
    }
}
