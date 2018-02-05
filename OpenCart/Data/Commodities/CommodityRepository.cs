using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart.Data.Commodities
{
    public class CommodityRepository
    {
        private volatile static CommodityRepository instance;
        private static object lockingObject = new object();

        private CommodityRepository() { }

        public static CommodityRepository Get()
        {
            if (instance == null)
            {
                lock (lockingObject)
                {
                    if (instance == null)
                    {
                        instance = new CommodityRepository();
                    }
                }
            }
            return instance;
        }

        public ICommodity MacBook()
        {
            return Commodity.Get().SetName("MacBook").Build();
        }

        public ICommodity IPhone()
        {
            return Commodity.Get().SetName("iPhone").Build();
        }
    }
}
