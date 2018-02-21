using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCart.Pages.User;

namespace OpenCart.Actions.User
{
	public class HomeActions : AHeadActions
	{
		public HomePage HomePageOperation { get; private set; }

		public HomeActions() : base()
		{
			HomePageOperation = new HomePage();
		}

		public HomeActions ChooseCurrencyByPartialName(string currencyName)
		{
			HomePageOperation.ClickCurrencyByPartialName(currencyName);
			//return this;
			return new HomeActions();
		}

		public double GetPriceByProductName(string productName)
		{
			return HomePageOperation.GetPriceAmountByProductName(productName);
		}

	}
}