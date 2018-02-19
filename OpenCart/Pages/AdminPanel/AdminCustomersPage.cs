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
    public class AdminCustomersPage : AdminDropDownColumn
    {
        //BrowserWrapper browserWrapper;

        protected IWebElement SearchEmail
        { get { return Search.Name("filter_email"); } }

        protected IWebElement Filter
        { get { return Search.Id("button-filter"); } }

        protected IWebElement Unlock
        { get { return Search.CssSelector(".fa.fa-unlock"); } }

        protected IWebElement TextCenter
        { get { return Search.ClassName("text-center"); } }

        protected IWebElement Delete
        { get { return Search.CssSelector(".btn.btn-danger"); } }

        protected IWebElement Close
        { get { return Search.ClassName("close"); } }

        public AdminCustomersPage() : base()
        {
            //browserWrapper = new BrowserWrapper();
        }

        //SearchEmail Field
        public void ClearSearchEmail()
        {
            SearchEmail.Clear();
        }

        public void SendKeysShoppingCart(string email)
        {
            SearchEmail.SendKeys(email);
        }

        //Filter Button
        public void ClickFilter()
        {
            Filter.Click();
        }

        //Unlock Button
        public void ClickUnlock()
        {
            Unlock.Click();
        }

        //Text Center
        public void ClickTextCenter()
        {
            TextCenter.Click();
        }

        //Delete Button
        public void ClickDelete()
        {
            Delete.Click();
        }

        //Close Button
        public void ClickClose()
        {
            Close.Click();
        }

        public bool GetUnlockCustomer(string email)
        {
            ClearSearchEmail();
            SendKeysShoppingCart(email);
            ClickFilter();
            Unlock.Click();
            return Close.Displayed;
        }

        public AdminCustomersPage GetDeletedCustomer(string email)
        {
            ClearSearchEmail();
            SendKeysShoppingCart(email);
            ClickFilter();
            ClickTextCenter();
            ClickDelete();
            return this;
            //browserWrapper.AcceptPopUp();
        }

        /////////////////////////////
        public AdminCustomersPage GetAcceptPopUp()
        {
            AdminCustomersPage adminLoginPage = Application.Get().AcceptPopUp();
            return this;
        }
    }
}
