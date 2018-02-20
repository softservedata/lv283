using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OpenCart.Pages.User
{
    public abstract class ARightComponent : ANavigatePanelComponent
    {
        //public ICollection<IWebElement> RightCategories { get; private set; }
        public IWebElement Logout
            { get { return Search.XPath("//div/a[contains(@href,'route=account/logout')]"); } }

        public ARightComponent() : base() { }

        // Logout
        public string GetLogoutText()
        {
            return Logout.Text;
        }

        public void ClickLogout()
        {
            Logout.Click();
        }

    }
}
