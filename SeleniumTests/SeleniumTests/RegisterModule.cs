using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace SeleniumTests
{
    public class RegisterModule
    {
        private IWebDriver driver;

        public RegisterModule(IWebDriver driver)
        {
            this.driver = driver;
        }

        public bool Register(string email, string password)
        {
            bool isRegistered = false;
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            //driver.Navigate().GoToUrl("http://zewer.beget.tech");
            driver.FindElement(By.ClassName("caret")).Click();
            driver.FindElement(By.LinkText("Register")).Click();
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys("qwerty");
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys("ytrewq");
            driver.FindElement(By.Name("email")).Clear();
            driver.FindElement(By.Name("email")).SendKeys(email);
            driver.FindElement(By.Name("telephone")).Clear();
            driver.FindElement(By.Name("telephone")).SendKeys("1234567");
            driver.FindElement(By.Name("fax")).Clear();
            driver.FindElement(By.Name("fax")).SendKeys("1234567");
            driver.FindElement(By.Name("company")).Clear();
            driver.FindElement(By.Name("company")).SendKeys("any");
            driver.FindElement(By.Name("address_1")).Clear();
            driver.FindElement(By.Name("address_1")).SendKeys("any");
            driver.FindElement(By.Name("address_2")).Clear();
            driver.FindElement(By.Name("address_2")).SendKeys("any");
            driver.FindElement(By.Name("city")).Clear();
            driver.FindElement(By.Name("city")).SendKeys("any");
            driver.FindElement(By.Name("postcode")).Clear();
            driver.FindElement(By.Name("postcode")).SendKeys("12345");

            SelectElement select1 = new SelectElement(driver.FindElement(By.Name("country_id")));
            IList<IWebElement> options1 = select1.Options;
            select1.SelectByText("United Kingdom");

            SelectElement select2 = new SelectElement(driver.FindElement(By.Name("zone_id")));
            IList<IWebElement> options2 = select2.Options;
            select2.SelectByText("Aberdeen");

            driver.FindElement(By.Name("password")).Clear();
            driver.FindElement(By.Name("password")).SendKeys(password);
            driver.FindElement(By.Name("confirm")).Clear();
            driver.FindElement(By.Name("confirm")).SendKeys(password);

            IList<IWebElement> rdBtn = driver.FindElements(By.Name("newsletter"));
            rdBtn.ElementAt(1).Click();
            driver.FindElement(By.Name("agree")).Click();

            driver.FindElement(By.CssSelector(".btn.btn-primary")).Click();

            if (driver.FindElement(By.CssSelector("a.list-group-item[href*='logout']")).Text == "Logout")
            {
                isRegistered = true;
            }

            return isRegistered;
        }

        public bool DeleteUser(string email)
        {
            bool isDeleted = false;
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Navigate().GoToUrl("http://zewer.beget.tech/admin");
            driver.FindElement(By.Name("username")).Clear();
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).Clear();
            driver.FindElement(By.Name("password")).SendKeys("lv-283");
            driver.FindElement(By.CssSelector(".btn.btn-primary")).Click();
            driver.FindElement(By.CssSelector(".fa.fa-user.fw")).Click();
            driver.FindElement(By.XPath("//li[@id='menu-customer']/ul/li")).Click();
            driver.FindElement(By.Name("filter_email")).Clear();
            driver.FindElement(By.Name("filter_email")).SendKeys(email);
            driver.FindElement(By.Id("button-filter")).Click();
            driver.FindElement(By.ClassName("text-center")).Click();
            driver.FindElement(By.CssSelector(".btn.btn-danger")).Click();

            driver.SwitchTo().Alert().Accept();
            //driver.FindElement(By.CssSelector(".fa.fa-trash-o")).Click();
            //alert alert-success

            if (driver.FindElement(By.ClassName("close")).Displayed)
            {
                isDeleted = true;
            }

            return isDeleted;
        }
    }
}
