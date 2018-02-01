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

        private const string Url = @"D:\SoftServe\ApiDemos-debug.apk";
        private const string Uri = "http://127.0.0.1:4723/wd/hub";

        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            DesiredCapabilities capabilities = new DesiredCapabilities();
            capabilities.SetCapability(MobileCapabilityType.App, Url);
            capabilities.SetCapability(MobileCapabilityType.DeviceName, "emulator-5554");
            capabilities.SetCapability(MobileCapabilityType.Udid, "emulator-5554");
            capabilities.SetCapability(MobileCapabilityType.PlatformVersion, "6.0.0");
            capabilities.SetCapability(MobileCapabilityType.PlatformName, "Android");
            capabilities.SetCapability(MobileCapabilityType.FullReset, "false");
            driver = new AndroidDriver<AndroidElement>(new Uri(Uri), capabilities);
            driver.Navigate().GoToUrl(Url);
        }

        [OneTimeTearDown]
        public void AfterAllMethods()
        {
            driver.CloseApp();
        }


        [SetUp]
        public void BeforeTest()
        {

        }

        [SetUp]
        public void AfterTest()
        {
            driver.ResetApp();
        }
    }
}
