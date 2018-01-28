using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Remote;
using System.Threading;

namespace AndroidAPKTests.Base
{

    public abstract class TestRunner
    {
        protected AppiumDriver<AndroidElement> driver;

        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            DesiredCapabilities capabilities = new DesiredCapabilities();

            capabilities.SetCapability(MobileCapabilityType.App, @"D:\TAQC\AndroidAPKTests\ApiDemos-debug.apk");
            capabilities.SetCapability(MobileCapabilityType.DeviceName, "emulator-5554");
            capabilities.SetCapability(MobileCapabilityType.Udid, "emulator-5554");
            capabilities.SetCapability(MobileCapabilityType.PlatformVersion, "6.0.0");
            capabilities.SetCapability(MobileCapabilityType.PlatformName, "Android");
            capabilities.SetCapability(MobileCapabilityType.FullReset, "false");

            driver = new AndroidDriver<AndroidElement>(new Uri("http://127.0.0.1:4723/wd/hub"), capabilities);
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));

        }

        [OneTimeTearDown]
        public void AfterAllMethods()
        {
            driver.CloseApp();
        }

        [SetUp]
        public void SetUp()
        {
            driver.FindElement(By.Id("Views")).Click();

            AndroidElement list = driver.FindElement(By.Id("android:id/list"));
            var locator = new ByAndroidUIAutomator("new UiScrollable(new UiSelector()).scrollIntoView("
                            + "new UiSelector().text(\"Tabs\"));");
            list.FindElement(locator);

            driver.FindElement(By.Id("Tabs")).Click();
        }

        [TearDown]
        public void TearDown()
        {
        }
    }
}
