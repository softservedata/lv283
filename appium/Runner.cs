using System;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Remote;

namespace appium
{
    [TestFixture]
    public class TestRunner
    {
        protected AppiumDriver<AndroidElement> driver;
        [OneTimeSetUp]
        public void BeforeAllMethods()
        {

            DesiredCapabilities capabilities = new DesiredCapabilities();
            capabilities.SetCapability(MobileCapabilityType.App, @"C:\Users\Andrew\AndroidStudioProjects\MyApplication\ApiDemos-debug.apk");
            capabilities.SetCapability(MobileCapabilityType.DeviceName, "emulator-5554");
            capabilities.SetCapability(MobileCapabilityType.Udid, "emulator-5554");
            capabilities.SetCapability(MobileCapabilityType.PlatformVersion, "6.0.0");
            capabilities.SetCapability(MobileCapabilityType.PlatformName, "Android");
            capabilities.SetCapability(MobileCapabilityType.FullReset, "false");
            driver = new AndroidDriver<AndroidElement>(new Uri("http://127.0.0.1:4723/wd/hub"), capabilities);
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(60));
        }
    }
}
