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
    public class MyAccountPage
    {
        protected ISearch Search { get; private set; }

        protected IWebElement Logout
        { get { return Search.CssSelector("a.list-group-item[href*='logout']"); } }

        public MyAccountPage()
        {
            this.Search = Application.Get().Search;
        }

        //Logout Button
        public void ClickLogout()
        {
            Logout.Click();
        }

        public LogoutPage GetLogoutUser()
        {
            ClickLogout();
            return new LogoutPage();
        }
    }
}
