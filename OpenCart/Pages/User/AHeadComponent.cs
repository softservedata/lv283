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
    public class DropdownOptions
    {
        protected ISearch Search { get; private set; }
        public ICollection<IWebElement> ListOptions { get; private set; }

        private DropdownOptions()
        {
            this.Search = Application.Get().Search;
        }

        public DropdownOptions(By searchLocator) : this()
        {
            InitListOptions(searchLocator);
        }

        public DropdownOptions(By searchLocator, By lastLocator) : this()
        {
            InitListOptions(searchLocator);
            ListOptions.Add(Search.GetWebElement(lastLocator));
        }

        private void InitListOptions(By searchLocator)
        {
            ListOptions = Search.GetWebElements(searchLocator);
        }

        public IWebElement GetDropdownOptionByPartialName(string optionName)
        {
            IWebElement result = null;
            foreach (IWebElement current in ListOptions)
            {
                if (current.Text.ToLower().Contains(optionName.ToLower()))
                {
                    result = current;
                    break;
                }
            }
            return result;
        }

        public List<string> GetListOptions()
        {
            List<string> result = new List<string>();
            foreach (IWebElement current in ListOptions)
            {
                result.Add(current.Text);
            }
            return result;
        }

        public void ClickDropdownOptionByPartialName(string optionName)
        {
            GetDropdownOptionByPartialName(optionName).Click();
        }
    }

    // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

    public abstract class AHeadComponent
    {
        public const string TAG_ATTRIBUTE_VALEU = "value";
        public const string TAG_ATTRIBUTE_HREF = "href";
        public const string FIRST_ANCHOR_CSS = "a:first-child";
        public const string MENUTOP_OPTIONS_XPATH = "//li/a[contains(text(),'{0}')]/..//li/a";
        public const string MENUTOP_LAST_OPTION_XPATH = "//a[contains(text(),'Show All {0}')]";
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
        private DropdownOptions dropdownOptions;
        private DropdownOptions currencyOptions;
        protected List<ProductComponent> ProductComponents { get; private set; }
        //private DropdownCart DropdownCart;

        protected AHeadComponent()
        {
            this.Search = Application.Get().Search;
            //
            // Verify Web Elements
            VerifyWebElements();
        }

        private void VerifyWebElements()
        {
            IWebElement verify = Currency;
            // TODO Check, if Web Elements Exist
        }

        protected void InitProductComponents(By searchLocator)
        {
            ProductComponents = new List<ProductComponent>();
            ICollection<IWebElement> productWebElements = Search.GetWebElements(searchLocator);
            foreach (IWebElement current in productWebElements)
            {
                ProductComponents.Add(new ProductComponent(current));
            }
        }

        // Currency
        public string GetCurrencyText()
        {
            return Currency.Text.Substring(0, 1);
        }

        public void ClickCurrency()
        {
            Currency.Click();
        }

        // MyAccount
        public string GetMyAccountText()
        {
            return MyAccount.Text;
        }

        public void ClickMyAccount()
        {
            MyAccount.Click();
        }

        // WishList
        public string GetWishListText()
        {
            return WishList.Text;
        }

        public int GetWishListNumber()
        {
            return RegexUtils.ExtractFirstNumber(GetWishListText());
        }

        public void ClickWishList()
        {
            WishList.Click();
        }

        // ShoppingCart
        public string GetShoppingCartText()
        {
            return ShoppingCart.Text;
        }

        public void ClickShoppingCart()
        {
            ShoppingCart.Click();
        }


        // Checkout
        public string GetCheckoutText()
        {
            return Checkout.Text;
        }

        public void ClickCheckout()
        {
            Checkout.Click();
        }

        // Logo
        public void ClickLogo()
        {
            Logo.Click();
        }

        // SearchProductField
        public string GetSearchProductFieldText()
        {
            return SearchProductField.GetAttribute(TAG_ATTRIBUTE_VALEU);
        }

        public void SetSearchProductField(string text)
        {
            SearchProductField.SendKeys(text);
        }

        public void ClearSearchProductField()
        {
            SearchProductField.Clear();
        }

        public void ClickSearchProductField()
        {
            SearchProductField.Click();
        }

        // SearchProductButton
        public void ClickSearchProductButton()
        {
            SearchProductButton.Click();
        }

        // Cart
        public string GetCartText()
        {
            return Cart.Text;
        }

        public int GetCartAmount()
        {
            return RegexUtils.ExtractFirstNumber(GetCartText());
        }

        public double GetCartSum()
        {
            return RegexUtils.ExtractFirstDouble(GetCartText());
        }

        public void ClickCart()
        {
            Cart.Click();
        }

        // MenuTop
        public IWebElement GetMenuTopByCategoryPartialName(string categoryName)
        {
            IWebElement result = null;
            foreach (IWebElement current in MenuTop)
            {
                if (Search.CssSelector(FIRST_ANCHOR_CSS, current)
                        .Text.ToLower().Contains(categoryName.ToLower()))
                {
                    result = current;
                    break;
                }
            }
            return result;
        }

        public List<string> GetMenuTopTexts()
        {
            List<string> result = new List<string>();
            foreach (IWebElement current in MenuTop)
            {
                result.Add(Search.CssSelector("a:first-child", current).Text);
            }
            return result;
        }

        public void ClickMenuTopByCategoryPartialName(string categoryName)
        {
            bool isClickable = false;
            foreach (string current in GetMenuTopTexts())
            {
                if (current.ToLower().Contains(categoryName.ToLower()))
                {
                    isClickable = true;
                }
            }
            if (!isClickable)
            {
                // TODO Develop Custom Exceptions
                throw new Exception("Menu Element not Found");
            }
            GetMenuTopByCategoryPartialName(categoryName).Click();
        }

        // DropdownOptions
        private void CreateDropdownOptions(By searchLocator, By lastLocator)
        {
            if (lastLocator == null)
            {
                dropdownOptions = new DropdownOptions(searchLocator);
            }
            else
            {
                dropdownOptions = new DropdownOptions(searchLocator, lastLocator);
            }
        }

        private void ClickDropdownOptionByPartialName(string optionName, By searchLocator, By lastLocator)
        {
            bool isClickable = false;
            CreateDropdownOptions(searchLocator, lastLocator);
            foreach (string current in dropdownOptions.GetListOptions())
            {
                if (current.ToLower().Contains(optionName.ToLower()))
                {
                    isClickable = true;
                }
            }
            if (!isClickable)
            {
                // TODO Develop Custom Exceptions
                throw new Exception("SubMenu Element " + optionName + " not Found");
            }
            dropdownOptions.ClickDropdownOptionByPartialName(optionName);
        }

        public void ClickSubMenuTopByPartialName(string categoryName, string optionName)
        {
            ClickMenuTopByCategoryPartialName(categoryName);
            ClickDropdownOptionByPartialName(optionName,
                    By.XPath(String.Format(MENUTOP_OPTIONS_XPATH, categoryName)),
                    By.XPath(String.Format(MENUTOP_LAST_OPTION_XPATH, categoryName)));
        }

        // CurrencyOptions
        private void InitcurrencyOptions()
        {
            ClickSearchProductField();
            ClickCurrency();
            currencyOptions = new DropdownOptions(By.CssSelector("button.currency-select.btn.btn-link.btn-block"));
        }

        public IWebElement GetCurrencyByPartialName(string currencyName)
        {
            InitcurrencyOptions();
            return currencyOptions.GetDropdownOptionByPartialName(currencyName);
        }

        public List<string> GetCurrencies()
        {
            InitcurrencyOptions();
            return currencyOptions.GetListOptions();
        }

        public void ClickCurrencyByPartialName(string currencyName)
        {
            InitcurrencyOptions();
            currencyOptions.ClickDropdownOptionByPartialName(currencyName);
        }

        // ProductComponents
        protected ProductComponent GetProductComponentByProductName(string productName)
        {
            //Console.WriteLine("ProductComponents.Count = " + ProductComponents.Count + "  productName = " + productName);
            ProductComponent result = null;
            foreach (ProductComponent current in ProductComponents)
            {
                //Console.WriteLine("current = " + current.Name + "  productName = " + productName);
                if (current.GetNameText().ToLower().Contains(productName.ToLower()))
                {
                    //Console.WriteLine("FOUND: ProductComponent current = " + current.Name);
                    result = current;
                    break;
                }
            }
            if (result == null)
            {
                // TODO Develop Custom Exceptions
                throw new Exception("ProductComponent " + productName + " not Found");
            }
            return result;
        }

        protected List<String> GetProductComponentTexts()
        {
            List<string> result = new List<string>();
            foreach (ProductComponent current in ProductComponents)
            {
                result.Add(current.GetNameText());
            }
            return result;
        }

        protected string GetPriceTextByProductName(string productName)
        {
            return GetProductComponentByProductName(productName).GetPriceText();
        }

        protected double GetPriceAmountByProductName(string productName)
        {
            //Console.WriteLine("public new double GetPriceAmountByProductName(string productName) productName = " + productName);
            return GetProductComponentByProductName(productName).GetPriceAmount();
        }

        protected void ClickAddToCartByProductName(string productName)
        {
            GetProductComponentByProductName(productName).ClickAddToCart();
        }

        protected void ClickAddToWishByProductName(string productName)
        {
            GetProductComponentByProductName(productName).ClickAddToWish();
        }

        // Business Logic
        public void GotoHome()
        {
            ClickLogo();
        }

        public void SuccesSearchProduct(string partialProductName)
        {
            ClickSearchProductField();
            ClearSearchProductField();
            SetSearchProductField(partialProductName);
            ClickSearchProductButton();
        }

    }
}
