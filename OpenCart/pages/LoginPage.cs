using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;


namespace OpenCart.pages
{
    public class LoginPage
    {
        IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement LoginField
        {
            get
            {
                return this.driver.FindElement(By.Name("email"));
            }
        }

        private IWebElement PaswField
        {
            get
            {
                return this.driver.FindElement(By.Id("input-password"));
            }
        }

        private IWebElement NextBtn
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='content']//input[@class = 'btn btn-primary']"));
            }
        }

        public string LoginIntoShop(string email, string pass)
        {
            LoginField.SendKeys(email);
            PaswField.SendKeys(pass);
            NextBtn.Click();
            return this.driver.FindElement(By.Id("content")).Text;
        }

        

    }
}
