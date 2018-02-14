using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
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
            AppiumDriver<AndroidElement> driver;
            //AndroidDriver<AppiumWebElement> driver;
            //AndroidDriver<AndroidElement> driver;
            DesiredCapabilities capabilities = new DesiredCapabilities();
            //
            // Your App File
            //FileStream app = File.Create(@"C:\Users\yharasym\AndroidStudioProjects\my1.apk");
            //capabilities.SetCapability(MobileCapabilityType.App, app);
            //capabilities.SetCapability(MobileCapabilityType.App, @"C:\Users\yharasym\AndroidStudioProjects\ApiDemos-debug.apk");
            capabilities.SetCapability(MobileCapabilityType.App, @"C:\Users\yharasym\AndroidStudioProjects\app-debug.apk");
            //
            // Needed if testing on IOS on a specific device. This will be the UDID
            // Running from CMD
            // ...\Android\Sdk\platform-tools>adb devices
            // emulator-5554   device
            //capabilities.SetCapability(MobileCapabilityType.DeviceName, "Nexus 5 API 23 Android 6");
            capabilities.SetCapability(MobileCapabilityType.DeviceName, "emulator-5554");
            //capabilities.SetCapability("deviceName", "Nexus 5 API 23 Android 6");
            //
            //capabilities.SetCapability(MobileCapabilityType.Udid, "Nexus_5_API_23_Android_6:5554");
            capabilities.SetCapability(MobileCapabilityType.Udid, "emulator-5554");
            //capabilities.SetCapability("udid", "Nexus_5_API_23_Android_6:5554");
            //
            capabilities.SetCapability(MobileCapabilityType.PlatformVersion, "6.0.0");
            //capabilities.SetCapability("platformVersion", "6.0.0");
            //
            capabilities.SetCapability(MobileCapabilityType.PlatformName, "Android");
            //capabilities.SetCapability("platformName", "Android");
            //
            capabilities.SetCapability(MobileCapabilityType.FullReset, "false");
            //capabilities.SetCapability(MobileCapabilityType.FullReset, "True");
            //capabilities.SetCapability("fullReset", "True");
            //
            //capabilities.SetCapability("appPackage", "edu.softserve.com.my");
            //capabilities.SetCapability("appActivity", "edu.softserve.com.my.MainActivity");
            //
            //capabilities.SetCapability("userName", SERVER_USER);
            //capabilities.SetCapability("password", SERVER_PASSWORD);
            //
            //driver = new RemoteWebDriver(new Uri("http://127.0.0.1:4723/wd/hub"), capabilities, TimeSpan.FromSeconds(180));
            //driver = new AndroidDriver<AndroidElement>(new Uri("http://127.0.0.1:4723/wd/hub"), capabilities, TimeSpan.FromMinutes(10));
            driver = new AndroidDriver<AndroidElement>(new Uri("http://127.0.0.1:4723/wd/hub"), capabilities);
            //
            //
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            //
            driver.FindElement(By.Id("edu.softserve.com.my:id/editText")).Clear();
            driver.FindElement(By.Id("edu.softserve.com.my:id/editText")).SendKeys("Ivan");
            driver.FindElement(By.Id("edu.softserve.com.my:id/button")).Click();
            //
            Thread.Sleep(4000);
            driver.CloseApp();
        }

    }
}
