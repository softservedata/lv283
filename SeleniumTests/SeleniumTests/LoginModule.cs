using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    //[TestClass]
    public class LoginModule
    {
        private IWebDriver driver;

        public LoginModule(IWebDriver driver)
        {
            this.driver = driver;
        }

        public bool Login(string email, string password)
        {            
            bool isLogged = false;
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            //driver.Navigate().GoToUrl("http://zewer.beget.tech");
            driver.FindElement(By.ClassName("caret")).Click();
            driver.FindElement(By.LinkText("Login")).Click();
            driver.FindElement(By.Name("email")).Clear();
            driver.FindElement(By.Name("email")).SendKeys(email);
            driver.FindElement(By.Name("password")).Clear();
            driver.FindElement(By.Name("password")).SendKeys(password);
            driver.FindElement(By.CssSelector(".btn.btn-primary:not(a)")).Click();

            if (driver.FindElement(By.CssSelector("a.list-group-item[href*='logout']")).Text == "Logout")
            {
                isLogged = true;
            }

            driver.FindElement(By.CssSelector("a.list-group-item[href*='logout']")).Click();

            return isLogged;
        }

        public bool LoginBlocked(string email, string password)
        {
            bool isBlocked = false;
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            //driver.Navigate().GoToUrl("http://zewer.beget.tech");
            driver.FindElement(By.ClassName("caret")).Click();
            driver.FindElement(By.LinkText("Login")).Click();
            for (var i = 0; i < 6; i++)
            {
                driver.FindElement(By.Name("email")).Clear();
                driver.FindElement(By.Name("email")).SendKeys(email);
                driver.FindElement(By.Name("password")).Clear();
                driver.FindElement(By.Name("password")).SendKeys(password);
                driver.FindElement(By.CssSelector(".btn.btn-primary:not(a)")).Click();
                //.alert.alert - danger
                if (i < 5)
                {
                    driver.FindElement(By.CssSelector(".alert.alert-danger"));
                }
            }
            //.fa.fa-exclamation-circle

            if (driver.FindElement(By.CssSelector(".alert.alert-danger")).Text ==
                "Warning: Your account has exceeded allowed number of login attempts. Please try again in 1 hour.")
            {
                isBlocked = true;
            }

            return isBlocked;
        }

        public bool Unblock(string email)
        {
            bool isNublocked = false;
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
            driver.FindElement(By.CssSelector(".fa.fa-unlock")).Click();

            if (driver.FindElement(By.ClassName("close")).Displayed)
            {
                isNublocked = true;
            }
            return isNublocked;
        }



        /*
        //[TestMethod]
        public void TestMethod1()
        {
            // Precondition
            //IWebDriver driver = new FirefoxDriver();
            //IWebDriver driver = new ChromeDriver(@"C:\Program Files (x86)\Google\Chrome\Application");
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://server7.pp.ua/");
            //
            // Steps
            IWebElement search = driver.FindElement(By.Name("search"));
            search.SendKeys("mac");
            IWebElement searchButton = driver.FindElement(By.CssSelector(".btn.btn-default.btn-lg"));
            searchButton.Click();
            //
            // Do not use Thread.Sleep(1000);
            Thread.Sleep(1000);
            IWebElement searchResult = driver.FindElement(By.XPath("//div[@class='caption']//a[contains(@href, '43&search=')]"));
            //
            // Check
            Assert.AreEqual("MacBook", searchResult.Text);
            //
            // Return to previous state
            Thread.Sleep(1000);
            driver.Quit();
            Console.WriteLine("done");
        }

        //[TestMethod]
        public void TestMethod2()
        {
            // Precondition
            //IWebDriver driver = new FirefoxDriver();
            IWebDriver driver = new ChromeDriver();
            // Set implicit waits
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            //
            //IWebDriver driver = new ChromeDriver(@"C:\Program Files (x86)\Google\Chrome\Application");
            //IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://regres.herokuapp.com/login");
            //
            // Steps
            //IWebElement login = driver.FindElement(By.Id("login"));
            driver.FindElement(By.Id("login")).SendKeys("ha-ha-ha");
            //login.SendKeys("ha-ha-ha");
            Thread.Sleep(2000);
            //
            driver.FindElement(By.Id("login")).Clear();
            //login.Clear();
            //
            //SelectElement language = new SelectElement(driver.FindElement(By.Id("changeLanguage")));
            //language.SelectByText("english");
            Thread.Sleep(2000);
            //
            driver.FindElement(By.Id("login")).SendKeys("admin");
            //login.SendKeys("admin");
            Thread.Sleep(1000);
            //
            IWebElement password = driver.FindElement(By.Id("password"));
            password.SendKeys("admin");
            Thread.Sleep(1000);
            //
            driver.FindElement(By.CssSelector(".btn.btn-primary")).Click();
            //password.Submit();
            //Thread.Sleep(3000);
            //
            // Check
            //IWebElement actual = driver.FindElement(By.CssSelector(".btn.btn-primary.btn-sm:not('.dropdown-toggle')"));
            //IWebElement actual = driver.FindElement(By.CssSelector(".btn.btn-primary.btn-sm")); // 2 results
            IWebElement actual = driver.FindElement(By.XPath("//button[@class='btn btn-primary btn-sm']"));
            Assert.AreEqual("admin", actual.Text);
            //
            // Return to previous state
            driver.FindElement(By.CssSelector(".btn.btn-primary.btn-sm.dropdown-toggle")).Click();
            driver.FindElement(By.XPath("//a[contains(@href, '/logout')]")).Click();
            Thread.Sleep(1000);
            //
            // Check
            actual = driver.FindElement(By.CssSelector(".login_logo.col-md-8.col-xs-12"));
            Assert.IsTrue(actual.GetAttribute("src").ToLower().Contains("ukraine_logo2.gif"));
            //
            driver.Quit();
            Console.WriteLine("done");
            
    }*/
    }
}
