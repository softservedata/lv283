using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart.pages
{
    public class HomePage
    {
        IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement OpenCartBtn
        {
            get
            {
                return driver.FindElement(By.XPath("//*[@id='logo']//img"));
            }
        }

        public IWebElement AddToCartMac
        {
            get
            {
                return driver.FindElement(By.XPath("//a[text()='MacBook']/../../../div[@class='button-group']/button[1]"));
            }
        }

        public IWebElement ShopCartList
        {
            get
            {
                return driver.FindElement(By.XPath("//*[@id='top-links']//a[@title='Shopping Cart']"));
            }
        }

        public IWebElement CheckOut
        {
            get
            {
                return driver.FindElement(By.XPath("//*[@id='content']//a[text() = 'Checkout']"));
            }
        }

        public IWebElement Delete
        {
            get
            {
                return driver.FindElement(By.XPath("//*[@id='content']//button[2]"));
            }
        }

        public IWebElement MyAccountBtn
        {
            get
            {
                return driver.FindElement(By.XPath("//*[@id='top-links']//a[@class='dropdown-toggle']"));
            }
        }

        public IWebElement LogOutBtn
        {
            get
            {
                return driver.FindElement(By.XPath("//*[@id='top-links']//a[text()='Logout']"));
            }
        }

        public IWebElement TabletsBtn
        {
            get
            {
                return driver.FindElement(By.XPath("//*[@id='menu']//a[text() = 'Tablets']"));
            }
        }

    }
}
