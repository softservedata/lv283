using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Remote;
using AndroidAPKTests.Base;
using System.Collections.Generic;
using System.Threading;

namespace AndroidAPKTests
{
    [TestFixture]
    public class APKTests : TestRunner
    {
        [Test]
        public void ContentByIDTabsTest()
        {
            driver.FindElementByAccessibilityId("1. Content By Id").Click();
            IList<AndroidElement> tabs = driver.FindElementsById("android:id/title");
            Assert.IsTrue(tabs[0].Selected);
            StringAssert.Contains("tab1", driver.FindElementById("tab1").Text);

            tabs[1].Click();
            Assert.IsTrue(tabs[1].Selected);
            StringAssert.Contains("tab2", driver.FindElementById("tab2").Text);

            tabs[2].Click();
            Assert.IsTrue(tabs[2].Selected);
            StringAssert.Contains("tab3", driver.FindElementById("tab3").Text);

        }

        [Test]
        public void ContentByFactoryTabsTest()
        {
            driver.FindElementByAccessibilityId("2. Content By Factory").Click();
            IList<AndroidElement> tabs = driver.FindElementsById("android:id/title");

            Assert.IsTrue(tabs[0].Selected);
            StringAssert.Contains("tab1", driver.FindElementByXPath(
                "//android.widget.FrameLayout/android.widget.TextView").Text);

            tabs[1].Click();
            Assert.IsTrue(tabs[1].Selected);
            StringAssert.Contains("tab2", driver.FindElementByXPath(
                "//android.widget.FrameLayout/android.widget.TextView").Text);

            tabs[2].Click();
            Assert.IsTrue(tabs[2].Selected);
            StringAssert.Contains("tab3", driver.FindElementByXPath(
                "//android.widget.FrameLayout/android.widget.TextView").Text);
        }

        [Test]
        public void ContentByIntentListTabTest()
        {
            driver.FindElementByAccessibilityId("3. Content By Intent").Click();
            IList<AndroidElement> tabs = driver.FindElementsById("android:id/title");

            Assert.IsTrue(tabs[0].Selected);
            Assert.IsTrue(driver.FindElementById("android:id/list").Displayed);
            IList<AndroidElement> items = driver.FindElementsById("android:id/text1");
            Assert.Greater(items.Count, 0);
        }

        [Test]
        public void ContentByIntentPhotoListTabTest()
        {
            driver.FindElementByAccessibilityId("3. Content By Intent").Click();
            IList<AndroidElement> tabs = driver.FindElementsById("android:id/title");

            tabs[1].Click();
            Assert.IsTrue(tabs[1].Selected);
            Assert.IsTrue(driver.FindElementById("io.appium.android.apis:id/add").Displayed);
            Assert.IsTrue(driver.FindElementById("io.appium.android.apis:id/clear").Displayed);
            StringAssert.AreEqualIgnoringCase("No photos", driver.FindElementById("io.appium.android.apis:id/empty").Text);

            driver.FindElementById("io.appium.android.apis:id/add").Click();
            IList<AndroidElement> images = driver.FindElements(By.XPath("//android.widget.ImageView"));
            Assert.AreEqual(1, images.Count);

            driver.FindElementById("io.appium.android.apis:id/add").Click();
            images = driver.FindElementsByXPath("//android.widget.ImageView");
            Assert.AreEqual(2, images.Count);

            driver.FindElementById("io.appium.android.apis:id/clear").Click();
            StringAssert.AreEqualIgnoringCase("No photos", driver.FindElementById("io.appium.android.apis:id/empty").Text);
        }

        [Test]
        public void ContentByIntentDestroyTabTest()
        {
            driver.FindElementByAccessibilityId("3. Content By Intent").Click();
            IList<AndroidElement> tabs = driver.FindElementsById("android:id/title");

            tabs[2].Click();
            Assert.IsTrue(tabs[2].Selected);

            Assert.IsTrue(driver.FindElementById("io.appium.android.apis:id/button").Enabled);
            Assert.IsFalse(driver.FindElementById("io.appium.android.apis:id/button_disabled").Enabled);

            driver.FindElementById("io.appium.android.apis:id/edit").SendKeys("1q");
            StringAssert.AreEqualIgnoringCase("1q", driver.FindElementById("io.appium.android.apis:id/edit").Text);

            AndroidElement[] checkboxes = { driver.FindElementById("io.appium.android.apis:id/check1"),
                driver.FindElementById("io.appium.android.apis:id/check2")};

            Assert.AreEqual("false", checkboxes[0].GetAttribute("checked"));
            Assert.AreEqual("false", checkboxes[1].GetAttribute("checked"));

            checkboxes[0].Click();
            Assert.AreEqual("true", checkboxes[0].GetAttribute("checked"));
            Assert.AreEqual("false", checkboxes[1].GetAttribute("checked"));

            checkboxes[1].Click();
            Assert.AreEqual("true", checkboxes[0].GetAttribute("checked"));
            Assert.AreEqual("true", checkboxes[1].GetAttribute("checked"));

            AndroidElement[] radiobuttons = { driver.FindElementById("io.appium.android.apis:id/radio1"),
                driver.FindElementById("io.appium.android.apis:id/radio2") };

            Assert.AreEqual("false", radiobuttons[0].GetAttribute("checked"));
            Assert.AreEqual("false", radiobuttons[1].GetAttribute("checked"));

            radiobuttons[0].Click();
            Assert.AreEqual("true", radiobuttons[0].GetAttribute("checked"));
            Assert.AreEqual("false", radiobuttons[1].GetAttribute("checked"));

            radiobuttons[1].Click();
            Assert.AreEqual("false", radiobuttons[0].GetAttribute("checked"));
            Assert.AreEqual("true", radiobuttons[1].GetAttribute("checked"));

            AndroidElement star = driver.FindElementById("io.appium.android.apis:id/star");

            Assert.AreEqual("false", star.GetAttribute("checked"));
            star.Click();
            Assert.AreEqual("true", star.GetAttribute("checked"));

            AndroidElement[] toggles = { driver.FindElementById("io.appium.android.apis:id/toggle1"),
                driver.FindElementById("io.appium.android.apis:id/toggle2") };

            Assert.IsTrue(toggles[0].GetAttribute("checked").Equals("false") && toggles[0].Text.Contains("OFF"));
            toggles[0].Click();
            Assert.IsTrue(toggles[0].GetAttribute("checked").Equals("true") && toggles[0].Text.Contains("ON"));

            Assert.IsTrue(toggles[1].GetAttribute("checked").Equals("false") && toggles[1].Text.Contains("OFF"));
            toggles[1].Click();
            Assert.IsTrue(toggles[1].GetAttribute("checked").Equals("true") && toggles[1].Text.Contains("ON"));

            StringAssert.AreEqualIgnoringCase("Mercury", driver.FindElementById("android:id/text1").Text);
            driver.FindElementById("android:id/text1").Click();
            IList<AndroidElement> elements = driver.FindElementsById("android:id/text1");
            elements[2].Click();
            StringAssert.AreEqualIgnoringCase("Earth", driver.FindElementById("android:id/text1").Text);
        }
    }
}
