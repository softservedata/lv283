using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCart.Pages.User;

namespace OpenCart.Actions.User
{
    public class SuccesSearchActions : HeadActions
    {
        public SuccesSearchPage SuccesSearchPageOperation { get; private set; }

        public SuccesSearchActions()
        {
            SuccesSearchPageOperation = new SuccesSearchPage();
        }

        public SuccesSearchActions ChooseCurrencyByPartialName(string currencyName)
        {
            SuccesSearchPageOperation.ClickCurrencyByPartialName(currencyName);
            //return this;
            return new SuccesSearchActions();
        }

        public double GetPriceByProductName(string productName)
        {
            return SuccesSearchPageOperation.GetPriceAmountByProductName(productName);
        }

    }
}
