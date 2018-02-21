using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCart.Pages.User;
using OpenQA.Selenium;


namespace OpenCart.Pages.User
{               //RightPage from dev. Was ARightComponent
    public class LogoutPage : RightPage //: ARightComponent
    {
        protected IWebElement Login
        { get { return Search.CssSelector("a.list-group-item[href*='login']"); } }

        public LogoutPage() : base()
        {
            //this.Search = Application.Get().Search;
        }

        //Logout Button
        public void ClickLogin()
        {
            Login.Click();
        }

        public bool IsLoginDisplayed()
        {
            return Login.Displayed;
        }
    }
}
