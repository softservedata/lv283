using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCart.Pages.User;

namespace OpenCart.Actions.User
{
    public class SubCategoryProductsActions
    {
        public SubCategoryProductsPage SubCategoryProductsPageOperation { get; private set; }

        public SubCategoryProductsActions()
        {
            SubCategoryProductsPageOperation = new SubCategoryProductsPage();
        }
    }
}
