using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;

namespace SeleniumTests
{
    [TestFixture]
    public class Tests
    {
        private IWebDriver driver;

        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);            
        }

        [OneTimeTearDown]
        public void AfterAllMethods()
        {
            driver.Quit();
        }

        [SetUp]
        public void BeforeTest()
        {
            driver.Navigate().GoToUrl("http://zewer.beget.tech");
        }

        /*Test case #2
        1. Open http://zewer.beget.tech
        2. Choose "My Account" -> "Login"
        3. Fill "E-Mail Address" and "Password" fields with the following data:
        "E-Mail Address" - random@random.com
        "Password" - 123456
        4. Click "Login" Button.
        5. Login operation should be done*/
        private static readonly object[] UserDataForLogin =
        {
            new object[] { "random@random.com", "123456"}
        };

        [Test, TestCaseSource(nameof(UserDataForLogin))]
        [Retry(20)]
        public void Login(string email, string password)
        {
            LoginModule login = new LoginModule(driver);

            Assert.IsTrue(login.Login(email, password));
        }

        /*Test case #3
        1. Open http://zewer.beget.tech
        2. Choose "My Account" -> "Login"
        3. Fill "E-Mail Address" field with "random@random.com" data and "Password" with "12321" data.
        4. Repeat in total 5 times.
        5. Account should be blocked for 1 hour*/
        private static readonly object[] UserDataForIncorrectLogin =
        {
            new object[] { "random@random.com", "12321"}
        };

        [Test, TestCaseSource(nameof(UserDataForIncorrectLogin))]
        [Retry(20)]
        public void LoginWithIncorrectData(string email, string password)
        {
            LoginModule login = new LoginModule(driver);

            Assert.IsTrue(login.LoginBlocked(email, password));
            Assert.IsTrue(login.Unblock(email));
        }

        /*Test case #1
        1. Open http://zewer.beget.tech
        2. Choose "My Account" -> "Register"
        3. Fill all fields with the following data:
        "First Name" - qwerty
        "Last Name" - ytrewq
        "E-Mail" - randomm@randomm.com
        "Telephone" - 1234321
        "Fax" - 1234321
        "Company" - any
        "Address 1" - any
        "Address 2" - any
        "City" - any
        "Post Code" - 12345
        "Country" - United Kingdom
        "Region/State" - Aberdeen
        "Password" - 123456
        "Password Confirm" - 123456
        "Subscribe" - No
        Confirm that you have read Privacy Policy
        4. Click "Continue" button.
        5. New user should be created.*/
        private static readonly object[] UserData =
        {
            new object[] { "randomm@randomm.com", "123456" }            
        };

        [Test, TestCaseSource(nameof(UserData))]
        [Retry(20)]
        public void Register(string email, string password)
        {           
            RegisterModule login = new RegisterModule(driver);

            Assert.IsTrue(login.Register(email, password));
            Assert.IsTrue(login.DeleteUser(email));
        }
    }
}
