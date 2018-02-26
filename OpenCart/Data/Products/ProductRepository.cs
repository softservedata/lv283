using System.Collections.Generic;

namespace OpenCart.Data.Products
{
	public sealed class ProductRepository
	{
		private ProductRepository() { }

		public static Product macBook()
		{
			Dictionary<string, double> macBookPrices = new Dictionary<string, double>();
			macBookPrices.Add("Euro", 472.33);
			macBookPrices.Add("Pound Sterling", 368.73);
			macBookPrices.Add("US Dollar", 602.00);
			return new Product("MacBook",
				"Intel Core 2 Duo processor Powered by an Intel Core 2 Duo processor at speeds up to 2.1..",
				macBookPrices);
		}

	}
}