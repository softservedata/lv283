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

        public SuccesSearchActions SuccesSearchProduct(string partialProductName)
        {
            HomePageOperation.SuccesSearchProduct(partialProductName);
            return new SuccesSearchActions();
        }

    }
}
