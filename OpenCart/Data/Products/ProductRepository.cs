using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart.Data.Products
{
    public sealed class ProductRepository
    {
        private ProductRepository() { }

        public static Product macBook()
        {
            Dictionary<string, double> macBookPrices = new Dictionary<string, double>();
            macBookPrices.Add("Euro", 560.94);
            macBookPrices.Add("Pound Sterling", 487.62);
            macBookPrices.Add("US Dollar", 602.00);
            return new Product("MacBook",
                "Intel Core 2 Duo processor Powered by an Intel Core 2 Duo processor at speeds up to 2.1..",
                macBookPrices);
        }

    }
}
