using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart.pages
{
    public class HomePage: MainPage
    {
        IWebDriver driver;

        public HomePage(IWebDriver driver): base(driver)
        {
            this.driver = driver;
        }

        public IWebElement LogOutBtn
        {
            get
            {
                return driver.FindElement(By.XPath("//*[@id='top-links']//a[text()='Logout']"));
            }
        }

    }
}
