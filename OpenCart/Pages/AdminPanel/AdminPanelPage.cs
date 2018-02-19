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
    public class AdminPanelPage : AdminDropDownColumn
    {
        public AdminPanelPage() : base()
        {
        }

        /*protected void ClickCustomersMenu()
        {
            CustomersMenu.Click();
        }

        protected void ClickCustomers()
        {
            Customers.Click();
        }*/

        public new void GetCustomers()
        {
            base.GetCustomers();
            //return new AdminCustomersPage();
        }
    }
}
