using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OpenCart
{
    public class AccessToAccount
    {

        private IWebDriver driver;

        public AccessToAccount(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void LogIn(string email, string password)
        {
            driver.FindElement(By.CssSelector(".fa.fa-user")).Click();
            driver.FindElement(By.XPath("//a[text()='Login']")).Click();
            driver.FindElement(By.Id("input-email")).SendKeys(email);
            driver.FindElement(By.Id("input-password")).SendKeys(password);
            driver.FindElement(By.Id("input-password")).Submit();
        }

        public void LogOut()
        {
            driver.FindElement(By.CssSelector(".fa.fa-user")).Click();
            driver.FindElement(By.XPath("//div[@id='top-links']//a[contains(@href, 'logout')]")).Click();
        }
    }
}
