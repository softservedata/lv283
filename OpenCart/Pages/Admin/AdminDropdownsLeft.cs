using OpenCart.Pages.User;
using OpenCart.Tools;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart.Pages.Admin
{
    class AdminDropdownsLeft : AHeadComponent
    {
        public IWebElement Notifications
        { get { return Search.ClassName(".fa.fa-bell.fa-lg"); } }

        public DropdownOptions notificationsOptions;
        
        private void CreateDropdownOptions(By searchLocator, By lastLocator)
        {
            if (lastLocator == null)
            {
                notificationsOptions = new DropdownOptions(searchLocator);
            }
            else
            {
                notificationsOptions = new DropdownOptions(searchLocator, lastLocator);
            }
        }

        private void ClickNotifications()
        {
            Notifications.Click();
        }

        private void CreateNotificationList()
        {
            ClickNotifications();
            CreateDropdownOptions(By.XPath("//ul[@class='dropdown-menu dropdown-menu-right alerts-dropdown']//a[contains(@href,'route=')]"), null);
        }

        public void ClickOption(string optionName)
        {
            CreateNotificationList();
            notificationsOptions.ClickDropdownOptionByPartialName(optionName);
        }
    }
}
