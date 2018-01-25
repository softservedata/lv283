using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Remote;

namespace OpenCart
{
    [TestFixture]
    public class AppiumTest
    {
        [Test]
        public void CheckAppiumAndroid()
        {
            //
            //ChromeOptions options = new ChromeOptions();
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
            AppiumDriver<AndroidElement> driver;
            //AndroidDriver driver;
            DesiredCapabilities capabilities = new DesiredCapabilities();
            //
            capabilities.SetCapability(MobileCapabilityType.DeviceName, "Nexus 5 API 23 Android 6");
            //capabilities.SetCapability("deviceName", "Nexus 5 API 23 Android 6");
            //
            capabilities.SetCapability(MobileCapabilityType.PlatformVersion, "6.0.0");
            //capabilities.SetCapability("platformVersion", "6.0.0");
            //
            capabilities.SetCapability(MobileCapabilityType.PlatformName, "Android");
            //capabilities.SetCapability("platformName", "Android");
            //
            capabilities.SetCapability(MobileCapabilityType.Udid, "Nexus_5_API_23_Android_6:5554");
            //capabilities.SetCapability("udid", "Nexus_5_API_23_Android_6:5554");
            //
            //capabilities.SetCapability(MobileCapabilityType.FullReset, "False");
            capabilities.SetCapability(MobileCapabilityType.FullReset, "True");
            //capabilities.SetCapability("fullReset", "True");
            //
            //capabilities.SetCapability(MobileCapabilityType.a, "True");
            //
            //FileStream app = File.Create(@"C:\Users\yharasym\AndroidStudioProjects\my1.apk");
            //capabilities.SetCapability(MobileCapabilityType.App, app);
            capabilities.SetCapability(MobileCapabilityType.App, @"C:\Users\yharasym\AndroidStudioProjects\my1.apk");
            driver = new AndroidDriver<AndroidElement>(new Uri("http://127.0.0.1:4723/wd/hub"), capabilities);
            //
            //
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            //driver.Navigate().GoToUrl("http://atqc-shop.epizy.com");
            //
            //driver.FindElement(By.CssSelector(".btn.btn-link.dropdown-toggle")).Click();
            Thread.Sleep(4000);
            driver.CloseApp();
        }

    }
}
