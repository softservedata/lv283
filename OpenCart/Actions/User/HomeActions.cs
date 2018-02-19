using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCart.Pages.User;

namespace OpenCart.Actions.User
{
    public class HomeActions
    {
        public HomePage HomePageOperation { get; private set; }

        public HomeActions()
        {
            HomePageOperation = new HomePage();
        }

        public HomeActions GotoHomeActions()
        {
            HomePageOperation.GotoHome();
            return new HomeActions();
        }

        public SuccesSearchActions SuccesSearchProduct(string partialProductName)
        {
            HomePageOperation.SuccesSearchProduct(partialProductName);
            return new SuccesSearchActions();
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

        public LoginAccountActions GetLoginPage()
        {
            HomePageOperation.GotoLogin();
            return new LoginAccountActions();
        }
    }
}
