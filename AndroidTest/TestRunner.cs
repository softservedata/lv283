using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Remote;

namespace AndroidTest
{
    public class TestRunner
    {
        protected AppiumDriver<AndroidElement> driver;

        private string url = @"D:\SoftServe\ApiDemos-debug.apk";
        private string uri = "http://127.0.0.1:4723/wd/hub";

        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            DesiredCapabilities capabilities = new DesiredCapabilities();
            capabilities.SetCapability(MobileCapabilityType.App, url);
            capabilities.SetCapability(MobileCapabilityType.DeviceName, "emulator-5554");
            capabilities.SetCapability(MobileCapabilityType.Udid, "emulator-5554");
            capabilities.SetCapability(MobileCapabilityType.PlatformVersion, "6.0.0");
            capabilities.SetCapability(MobileCapabilityType.PlatformName, "Android");
            capabilities.SetCapability(MobileCapabilityType.FullReset, "false");
            driver = new AndroidDriver<AndroidElement>(new Uri("http://127.0.0.1:4723/wd/hub"), capabilities);
            driver.Navigate().GoToUrl(@"D:\SoftServe\ApiDemos-debug.apk");
        }

        [OneTimeTearDown]
        public void AfterAllMethods()
        {
            
        }


        [SetUp]
        public void BeforeTest()
        {

        }

        [SetUp]
        public void AfterTest()
        {

        }
    }
}
