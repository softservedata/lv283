using System.Collections.Generic;
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
            return new SuccesSearchActions();
        }

        public double GetPriceByProductName(string productName)
        {
            return SuccesSearchPageOperation.GetPriceAmountByProductName(productName);
        }

        public List<string> GetProductComponentTexts()
        {
            return SuccesSearchPageOperation.GetProductComponentTexts();
        }

    }
}
