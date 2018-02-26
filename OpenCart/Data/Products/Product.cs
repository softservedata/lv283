using System.Collections.Generic;

namespace OpenCart.Data.Products
{
	public class Product
	{
		public string Name { get; private set; }
		public string Description { get; private set; }
		public Dictionary<string, double> Prices { get; private set; }

		// TODO Develop Builder

		public Product(string name, string description, Dictionary<string, double> prices)
		{
			this.Name = name;
			this.Description = description;
			this.Prices = prices;
		}

		public Product(string name, string description)
		{
			this.Name = name;
			this.Description = description;
			this.Prices = new Dictionary<string, double>();
		}

		public double GetPrice(string currencyName)
		{
			return Prices[currencyName];
		}

	}
}
