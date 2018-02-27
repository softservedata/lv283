using OpenCart.Pages.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart.Actions.User
{
    public class WishListActions
    {
        public WishListPage WishListPageOperation { get; private set; }

        public WishListActions()
        {
            WishListPageOperation = new WishListPage();
        }

        public WishListActions ClickRemoveFromWish(string productName)
        {
            WishListPageOperation.ClickRemoveFromToWish(productName);
            return new WishListActions();
        }

        public WishedProductComponent VerifyProductExistence(string productName)
        {
            try
            {
                WishListPageOperation.GetProductComponentByProductName(productName);
            }
            catch (Exception)
            {
                Console.WriteLine("Exeption");
            }
            return WishListPageOperation.GetProductComponentByProductName(productName);
        }
    }
}
