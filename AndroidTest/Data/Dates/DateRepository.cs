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

        public IDate Tomorrow()
        {
            return Date.Get()
                .SetMonth(Month.February)
                .SetDay("14")
                .SetYear("2021")
                .Build();
        }

        public IDate AfterTomorrow()
        {
            return Date.Get()
                .SetMonth(Month.February)
                .SetDay("16")
                .SetYear("2022")
                .Build();
        }
    }
}
