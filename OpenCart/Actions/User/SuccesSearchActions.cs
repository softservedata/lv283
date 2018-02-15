using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCart.Pages.User;

namespace OpenCart.Actions.User
{
    public class SuccesSearchActions
    {
        public SuccesSearchPage SuccesSearchPageOperation { get; private set; }

        public SuccesSearchActions()
        {
            SuccesSearchPageOperation = new SuccesSearchPage();
        }

        public SuccesSearchActions SuccesSearchProduct(string partialProductName)
        {
            SuccesSearchPageOperation.SuccesSearchProduct(partialProductName);
            return new SuccesSearchActions();
        }

    }
}
