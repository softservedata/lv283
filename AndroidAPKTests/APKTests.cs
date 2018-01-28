using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Remote;
using AndroidAPKTests.Base;

namespace AndroidAPKTests
{
    [TestFixture]
    public class APKTests : TestRunner
    {
        [Test]
        public void SimpleTabsTest()
        {
            driver.FindElement(By.Id("1. Content By Id")).Click();
            //AndroidElement tabs = driver.FindElement(By.Id("android:id/tabs"));
            driver.FindElement(By.XPath("android.widget.TextView[contains(text(),'tab3']")).Click();
        }

    }

}
