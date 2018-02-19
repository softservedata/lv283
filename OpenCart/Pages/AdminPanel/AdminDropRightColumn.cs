using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenCart.Tools;
using OpenCart.Pages.User;

namespace OpenCart.Pages.AdminPanel
{
    public abstract class AdminDropDownColumn
    {
        protected ISearch Search { get; private set; }
        //

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
