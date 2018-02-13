using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenCart.Tools;

namespace OpenCart.Pages.User
{
    public class AHeadComponent
    {
        protected ISearch Search { get; private set; }
        //
        public IWebElement Currency
            { get { return Search.CssSelector(".btn.btn-link.dropdown-toggle"); } }
        public IWebElement MyAccount
            { get { return Search.CssSelector(".list-inline > li > a.dropdown-toggle"); } }
        public IWebElement WishList
            { get { return Search.Id("wishlist-total"); } }
        public IWebElement ShoppingCart
            { get { return Search.CssSelector("a[title='Shopping Cart']"); } }
        public IWebElement Checkout
            { get { return Search.CssSelector("a[title='Checkout']"); } }
        public IWebElement Logo
            { get { return Search.CssSelector("#logo > a"); } }
        public IWebElement SearchProductField
            { get { return Search.Name("search"); } }
        public IWebElement SearchProductButton
            { get { return Search.CssSelector(".btn.btn-default.btn-lg"); } }
        public IWebElement Cart
            { get { return Search.CssSelector("#cart > button"); } }
        public ICollection<IWebElement> MenuTop
            { get { return Search.CssSelectors("ul.nav.navbar-nav > li"); } }
        //
        //protected ICollection<ProductComponent> ProductComponents;
        //private DropdownOptions DropdownOptions;
        //private DropdownCart DropdownCart;

        protected AHeadComponent()
        {
            this.Search = Application.Get().Search;
            // Verify
            IWebElement verify = Currency;
        }

    }
}
