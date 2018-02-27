using OpenCart.Tools;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart.Pages.User
{
    public class WishListPage
    {
        public ISearch Search { get; private set; }

        List<WishedProductComponent> ProductComponents;

        public WishListPage()
        {
            this.Search = Application.Get().Search;
            InitProductComponents(By.CssSelector("div.table-responsive > table > tbody > tr"));
        }


        public void InitProductComponents(By searchLocator)
        {
            ProductComponents = new List<WishedProductComponent>();
            ICollection<IWebElement> productWebElements = Search.GetWebElements(searchLocator);
            foreach (IWebElement current in productWebElements)
            {
                ProductComponents.Add(new WishedProductComponent(current));
            }
        }

        public WishedProductComponent GetProductComponentByProductName(string productName)
        {
            WishedProductComponent result = null;
            foreach (WishedProductComponent current in ProductComponents)
            {
                if (current.GetNameText().ToLower().Contains(productName.ToLower()))
                {
                    result = current;
                    break;
                }
            }
            if (result == null)
            {
                throw new Exception("ProductComponent " + productName + " not Found");
            }
            return result;
        }

        public void ClickRemoveFromToWish(string productName)
        {
            GetProductComponentByProductName(productName).ClickRemoveFromWish();
        }

    }
}
