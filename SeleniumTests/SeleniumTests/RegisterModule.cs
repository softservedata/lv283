using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;
using SeleniumTests.Data.Users;
using System;

namespace SeleniumTests
{
    public class RegisterModule
    {
        private IWebDriver driver;

        public RegisterModule(IWebDriver driver)
        {
            this.driver = driver;
        }

        public bool Register(IUser user)
        {
            driver.FindElement(By.ClassName("caret")).Click();
            driver.FindElement(By.LinkText("Register")).Click();
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(user.GetFirstname());
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(user.GetLastname());
            driver.FindElement(By.Name("email")).Clear();
            driver.FindElement(By.Name("email")).SendKeys(user.GetEmail());
            driver.FindElement(By.Name("telephone")).Clear();
            driver.FindElement(By.Name("telephone")).SendKeys(user.GetPhone());
            driver.FindElement(By.Name("fax")).Clear();
            driver.FindElement(By.Name("fax")).SendKeys(user.GetFax());
            driver.FindElement(By.Name("company")).Clear();
            driver.FindElement(By.Name("company")).SendKeys(user.GetCompany());
            driver.FindElement(By.Name("address_1")).Clear();
            driver.FindElement(By.Name("address_1")).SendKeys(user.GetAddressMain());
            driver.FindElement(By.Name("address_2")).Clear();
            driver.FindElement(By.Name("address_2")).SendKeys(user.GetAddressAdd());
            driver.FindElement(By.Name("city")).Clear();
            driver.FindElement(By.Name("city")).SendKeys(user.GetCity());
            driver.FindElement(By.Name("postcode")).Clear();
            driver.FindElement(By.Name("postcode")).SendKeys(user.GetPostcode());

            SelectElement select1 = new SelectElement(driver.FindElement(By.Name("country_id")));
            IList<IWebElement> options1 = select1.Options;
            select1.SelectByText(user.GetCoutry());

            SelectElement select2 = new SelectElement(driver.FindElement(By.Name("zone_id")));
            IList<IWebElement> options2 = select2.Options;
            select2.SelectByText(user.GetRegionState());

            driver.FindElement(By.Name("password")).Clear();
            driver.FindElement(By.Name("password")).SendKeys(user.GetPassword());
            driver.FindElement(By.Name("confirm")).Clear();
            driver.FindElement(By.Name("confirm")).SendKeys(user.GetPassword());

            IList<IWebElement> rdBtn = driver.FindElements(By.Name("newsletter"));

            if (Convert.ToInt32(user.GetSubscribe()) == 1)
            {
                rdBtn.ElementAt(0).Click();
            }
            else
            {
                rdBtn.ElementAt(1).Click();
            }
            //rdBtn.ElementAt(Convert.ToInt32(user.GetSubscribe())).Click();

            driver.FindElement(By.Name("agree")).Click();

            driver.FindElement(By.CssSelector(".btn.btn-primary")).Click();

            return (driver.FindElement(By.CssSelector("a.list-group-item[href*='logout']")).Text == "Logout");
        }

        public bool DeleteUser(IUser user)
        {
            string admin = "admin";
            string adminPassword = "lv-283";
            string adminPanelLink = "http://zewer.beget.tech/admin";

            driver.Navigate().GoToUrl(adminPanelLink);
            driver.FindElement(By.Name("username")).Clear();
            driver.FindElement(By.Name("username")).SendKeys(admin);
            driver.FindElement(By.Name("password")).Clear();
            driver.FindElement(By.Name("password")).SendKeys(adminPassword);
            driver.FindElement(By.CssSelector(".btn.btn-primary")).Click();
            driver.FindElement(By.CssSelector(".fa.fa-user.fw")).Click();
            driver.FindElement(By.XPath("//li[@id='menu-customer']/ul/li")).Click();
            driver.FindElement(By.Name("filter_email")).Clear();
            driver.FindElement(By.Name("filter_email")).SendKeys(user.GetEmail());
            driver.FindElement(By.Id("button-filter")).Click();
            driver.FindElement(By.ClassName("text-center")).Click();
            driver.FindElement(By.CssSelector(".btn.btn-danger")).Click();
            driver.SwitchTo().Alert().Accept();

            return (driver.FindElement(By.ClassName("close")).Displayed);
        }
    }
}
