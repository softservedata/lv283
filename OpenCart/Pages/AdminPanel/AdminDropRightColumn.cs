using OpenQA.Selenium;
using OpenCart.Tools;

namespace OpenCart.Pages.AdminPanel
{
    public abstract class AdminDropDownColumn
    {
        protected ISearch Search { get; private set; }

        protected IWebElement CustomersMenu
        { get { return Search.CssSelector(".fa.fa-user.fw"); } }

        protected IWebElement Customers
        { get { return Search.XPath("//li[@id='menu-customer']/ul/li"); } }

        public AdminDropDownColumn()
        {
            this.Search = Application.Get().Search;
        }

        protected void ClickCustomersMenu()
        {
            CustomersMenu.Click();
        }

        protected void ClickCustomers()
        {
            Customers.Click();
        }

        protected void GetCustomers()
        {
            ClickCustomersMenu();
            ClickCustomers();
        }

    }
}
