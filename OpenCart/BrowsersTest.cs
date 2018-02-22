using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace OpenCart
{
    [TestFixture]
    public class BrowsersTest
    {
        private ChromeDriverService service;
        private IWebDriver driver;

        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            service = ChromeDriverService.CreateDefaultService();
            //    .CreateDefaultService("./chromedriver.exe");
            service.Port = 8888;
            service.Start();
        }

        [OneTimeTearDown]
        public void AfterAllMethods()
        {
            if (driver != null)
            {
                driver.Quit();
            }
            if (service != null)
            {
                service.Dispose();
            }
        }

        [SetUp]
        public void SetUp()
        {
            //driver.Navigate().GoToUrl("http://atqc-shop.epizy.com");
        }

        [TearDown]
        public void TearDown()
        {
            //Console.WriteLine("[TearDown] TearDown()");
        }

        //[Test]
        public void CheckRemoteServer()
        {
            //
            ChromeOptions options = new ChromeOptions();
            //options.AddArguments("--start-maximized");
            //options.AddArguments("--no-proxy-server");
            //options.AddArguments("--no-sandbox");
            //options.AddArguments("--disable-web-security");
            //options.AddArguments("--ignore-certificate-errors");
            //options.AddArguments("--disable-extensions");
            //options.BinaryLocation = @"C:\Users\yharasym\Downloads\ChromiumPortable\ChromiumPortable.exe";
            //driver = new ChromeDriver(options);
            //
            // Deprecated
            //DesiredCapabilities capabilities = DesiredCapabilities.Chrome();
            //driver = new RemoteWebDriver(new Uri("127.0.0.1:8888"), capabilities);
            //driver = new RemoteWebDriver(service.ServiceUrl, capabilities);
            //
            // Do not Work
            //DesiredCapabilities capabilities = new DesiredCapabilities();
            //capabilities.SetCapability(ChromeOptions.Capability, options);
            //driver = new RemoteWebDriver(service.ServiceUrl, capabilities);
            //
            // Ok
            driver = new RemoteWebDriver(service.ServiceUrl, options);
            //
            Console.WriteLine("\t+++RemoteWebDriver Start, service.ServiceUrl =" + service.ServiceUrl);
            //
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Navigate().GoToUrl("http://atqc-shop.epizy.com");
            //
            driver.FindElement(By.CssSelector(".btn.btn-link.dropdown-toggle")).Click();
            Thread.Sleep(4000);
        }
    }
}
