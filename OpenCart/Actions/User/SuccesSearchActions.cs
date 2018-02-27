using System.Collections.Generic;
using OpenCart.Pages.User;

namespace OpenCart.Actions.User
{
    public class SuccessSearchActions : HeadActions
    {
        public SuccessSearchPage SuccessSearchPageOperation { get; private set; }

        public SuccessSearchActions()
        {
            SuccessSearchPageOperation = new SuccessSearchPage();
        }

        public SuccessSearchActions ChooseCurrencyByPartialName(string currencyName)
        {
            SuccessSearchPageOperation.ClickCurrencyByPartialName(currencyName);
            return new SuccessSearchActions();
        }

        public double GetPriceByProductName(string productName)
        {
            return SuccessSearchPageOperation.GetPriceAmountByProductName(productName);
        }

        public List<string> GetProductComponentTextList()
        {
            return SuccessSearchPageOperation.GetProductComponentTextList();
        }

    }
}
