using OpenCart.Tools;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart.Pages.User
{
    public class WishedProductComponent
    {
        protected ISearch Search { get; private set; }
        public IWebElement ProductLayout { get; private set; }
        //
        public IWebElement Name
        { get { return Search.CssSelector("td:nth-child(2) > a", ProductLayout); } }
        public IWebElement RemoveFromWish
        { get { return Search.CssSelector(".btn.btn-danger", ProductLayout); } }

        public WishedProductComponent(IWebElement productLayout)
        {
            this.Search = Application.Get().Search;
            this.ProductLayout = productLayout;
        }

        public string GetNameText()
        {
            return Name.Text;
        }

        public void ClickName()
        {
            Name.Click();
        }

        public void ClickRemoveFromWish()
        {
            RemoveFromWish.Click();
        }

    }
}
