using System;
using OpenQA;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Enums;

namespace AppiumDemo
{
    public abstract class TestRunner
    {
        protected AppiumDriver<AndroidElement> driver;

        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            DesiredCapabilities capabilities = new DesiredCapabilities();

            capabilities.SetCapability(MobileCapabilityType.App, @"C:\Users\yharasym\Desktop\ApiDemos.apk");
            capabilities.SetCapability(MobileCapabilityType.DeviceName, "emulator-5554");
            capabilities.SetCapability(MobileCapabilityType.Udid, "emulator-5554");
            capabilities.SetCapability(MobileCapabilityType.PlatformVersion, "6.0.0");
            capabilities.SetCapability(MobileCapabilityType.PlatformName, "Android");
            capabilities.SetCapability(MobileCapabilityType.FullReset, "false");

            driver = new AndroidDriver<AndroidElement>(new Uri("http://127.0.0.1:4723/wd/hub"), capabilities);
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));
        }

        [OneTimeSetUp]
        public void SetUp()
        {
            driver.FindElement(By.Id("Views")).Click();
            AndroidElement list = driver.FindElement(By.Id("android:id/list"));
            var locator = new ByAndroidUIAutomator("new UiScrollable(new UiSelector()).scrollIntoView("
                            + "new UiSelector().text(\"Progress Bar\"));");
            list.FindElement(locator);
            driver.FindElement(By.Id("Progress Bar")).Click();
        }

        [TearDown]
        public void GoBack()
        {
            driver.Navigate().Back();
        }

        [OneTimeTearDown]
        public void CloseApplication()
        {
            driver.CloseApp();
        }
    }
}