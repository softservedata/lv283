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
            Assert.IsTrue(driver.FindElementById("tab1").Text.Contains("tab1"));

            tabs[1].Click();
            Assert.IsTrue(tabs[1].Selected);
            Assert.IsTrue(driver.FindElementById("tab2").Text.Contains("tab2"));

            tabs[2].Click();
            Assert.IsTrue(tabs[2].Selected);
            Assert.IsTrue(driver.FindElementById("tab3").Text.Contains("tab3"));

        }

        [Test]
        public void ContentByFactoryTabsTest()
        {
            driver.FindElementByAccessibilityId("2. Content By Factory").Click();
            IList<AndroidElement> tabs = driver.FindElementsById("android:id/title");

            Assert.IsTrue(tabs[0].Selected);
            Assert.IsTrue(driver.FindElementByXPath("//android.widget.FrameLayout/android.widget.TextView")
                .Text.Contains("tab1"));

            tabs[1].Click();
            Assert.IsTrue(tabs[1].Selected);
            Assert.IsTrue(driver.FindElementByXPath("//android.widget.FrameLayout/android.widget.TextView")
                .Text.Contains("tab2"));

            tabs[2].Click();
            Assert.IsTrue(tabs[2].Selected);
            Assert.IsTrue(driver.FindElementByXPath("//android.widget.FrameLayout/android.widget.TextView")
                .Text.Contains("tab3"));
        }

        [Test]
        public void ContentByIntentListTabTest()
        {
            driver.FindElementByAccessibilityId("3. Content By Intent").Click();
            IList<AndroidElement> tabs = driver.FindElementsById("android:id/title");

            Assert.IsTrue(tabs[0].Selected);
            Assert.IsTrue(driver.FindElementById("android:id/list").Displayed);
            IList<AndroidElement> items = driver.FindElementsById("android:id/text1");
            Assert.IsTrue(items.Count > 0);
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
            Assert.IsTrue(driver.FindElementById("io.appium.android.apis:id/empty").Text.Contains("No photos"));

            driver.FindElementById("io.appium.android.apis:id/add").Click();
            IList<AndroidElement> images = driver.FindElements(By.XPath("//android.widget.ImageView"));
            Assert.IsTrue(images.Count == 1);

            driver.FindElementById("io.appium.android.apis:id/add").Click();
            images = driver.FindElementsByXPath("//android.widget.ImageView");
            Assert.IsTrue(images.Count == 2);

            driver.FindElementById("io.appium.android.apis:id/clear").Click();
            Assert.IsTrue(driver.FindElementById("io.appium.android.apis:id/empty").Text.Contains("No photos"));
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
            Assert.IsTrue(driver.FindElementById("io.appium.android.apis:id/edit").Text.Contains("1q"));

            AndroidElement[] checkboxes = { driver.FindElementById("io.appium.android.apis:id/check1"),
                driver.FindElementById("io.appium.android.apis:id/check2")};

            Assert.IsTrue(checkboxes[0].GetAttribute("checked").Equals("false"));
            Assert.IsTrue(checkboxes[1].GetAttribute("checked").Equals("false"));

            checkboxes[0].Click();
            Assert.IsTrue(checkboxes[0].GetAttribute("checked").Equals("true"));
            Assert.IsTrue(checkboxes[1].GetAttribute("checked").Equals("false"));

            checkboxes[1].Click();
            Assert.IsTrue(checkboxes[0].GetAttribute("checked").Equals("true"));
            Assert.IsTrue(checkboxes[1].GetAttribute("checked").Equals("true"));

            AndroidElement[] radiobuttons = { driver.FindElementById("io.appium.android.apis:id/radio1"),
                driver.FindElementById("io.appium.android.apis:id/radio2") };

            Assert.IsTrue(radiobuttons[0].GetAttribute("checked").Equals("false"));
            Assert.IsTrue(radiobuttons[1].GetAttribute("checked").Equals("false"));

            radiobuttons[0].Click();
            Assert.IsTrue(radiobuttons[0].GetAttribute("checked").Equals("true"));
            Assert.IsTrue(radiobuttons[1].GetAttribute("checked").Equals("false"));

            radiobuttons[1].Click();
            Assert.IsTrue(radiobuttons[0].GetAttribute("checked").Equals("false"));
            Assert.IsTrue(radiobuttons[1].GetAttribute("checked").Equals("true"));

            AndroidElement star = driver.FindElementById("io.appium.android.apis:id/star");

            Assert.IsTrue(star.GetAttribute("checked").Equals("false"));
            star.Click();
            Assert.IsTrue(star.GetAttribute("checked").Equals("true"));

            AndroidElement[] toggles = { driver.FindElementById("io.appium.android.apis:id/toggle1"),
                driver.FindElementById("io.appium.android.apis:id/toggle2") };

            Assert.IsTrue(toggles[0].GetAttribute("checked").Equals("false") && toggles[0].Text.Contains("OFF"));
            toggles[0].Click();
            Assert.IsTrue(toggles[0].GetAttribute("checked").Equals("true") && toggles[0].Text.Contains("ON"));

            Assert.IsTrue(toggles[1].GetAttribute("checked").Equals("false") && toggles[1].Text.Contains("OFF"));
            toggles[1].Click();
            Assert.IsTrue(toggles[1].GetAttribute("checked").Equals("true") && toggles[1].Text.Contains("ON"));

            Assert.IsTrue(driver.FindElementById("android:id/text1").Text.Contains("Mercury"));
            driver.FindElementById("android:id/text1").Click();
            IList<AndroidElement> elements = driver.FindElementsById("android:id/text1");
            elements[2].Click();
            Assert.IsTrue(driver.FindElementById("android:id/text1").Text.Contains("Earth"));
        }
    }
}
