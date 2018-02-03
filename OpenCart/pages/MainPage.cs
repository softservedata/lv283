using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart.pages
{
    public class MainPage
    {
        IWebDriver driver;

        public MainPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement MyAccountBtn
        {
            get
            {
                return driver.FindElement(By.XPath("//*[@id='top-links']//a[@class='dropdown-toggle']"));
            }
        }

        public IWebElement LoginBtn
        {
            get
            {
                return driver.FindElement(By.XPath("//*[@id='top-links']//a[text()='Login']"));
            }
        }
    }
}
