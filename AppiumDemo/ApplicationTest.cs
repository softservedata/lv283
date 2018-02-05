using System;
using AppiumDemo;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Remote;


namespace AppiumDemo
{
    [TestFixture]
    public class ApplicationTest : TestRunner
    {
        [Test, Order(1)]
        public void IncrementalProgressBarTest()
        {
            driver.FindElement(By.Id("1. Incremental")).Click();
            bool progressBarIsVisible = driver.FindElement(By.Id("io.appium.android.apis:id/progress_horizontal")).Enabled;
            //Check
            Assert.IsTrue(progressBarIsVisible);

            driver.FindElement(By.Id("io.appium.android.apis:id/decrease")).Click();
            bool buttonDefDecrIsVisible = driver.FindElement(By.Id("io.appium.android.apis:id/decrease")).Displayed;
            bool buttonDefDecrIsClickable = driver.FindElement(By.Id("io.appium.android.apis:id/decrease")).Enabled;
            //Check
            Assert.IsTrue(buttonDefDecrIsVisible);
            Assert.IsTrue(buttonDefDecrIsClickable);

            driver.FindElement(By.Id("io.appium.android.apis:id/increase")).Click();
            bool buttonDefIncrIsVisible = driver.FindElement(By.Id("io.appium.android.apis:id/increase")).Displayed;
            bool buttonDefIncrIsClickable = driver.FindElement(By.Id("io.appium.android.apis:id/increase")).Enabled;
            //Check
            Assert.IsTrue(buttonDefIncrIsVisible);
            Assert.IsTrue(buttonDefIncrIsClickable);

            driver.FindElement(By.Id("io.appium.android.apis:id/decrease_secondary")).Click();
            bool buttonSecDecrIsVisible = driver.FindElement(By.Id("io.appium.android.apis:id/decrease_secondary")).Displayed;
            bool buttonSecDecrIsClickable = driver.FindElement(By.Id("io.appium.android.apis:id/decrease_secondary")).Enabled;
            //Check
            Assert.IsTrue(buttonSecDecrIsVisible);
            Assert.IsTrue(buttonSecDecrIsClickable);

            driver.FindElement(By.Id("io.appium.android.apis:id/increase_secondary")).Click();
            bool buttonSecIncrIsVisible = driver.FindElement(By.Id("io.appium.android.apis:id/increase_secondary")).Displayed;
            bool buttonSecIncrIsClickable = driver.FindElement(By.Id("io.appium.android.apis:id/increase_secondary")).Enabled;
            //Check
            Assert.IsTrue(buttonSecDecrIsVisible);
            Assert.IsTrue(buttonSecIncrIsClickable);

        }

        [Test, Order(2)]
        public void SmoothProgressBarTest()
        {
            driver.FindElement(By.Id("2. Smooth")).Click();

            //Check
            bool labelIsEnabled = driver.FindElement(By.Id("android:attr/label")).Enabled;
            Assert.IsTrue(labelIsEnabled);
            //Check
            bool progressIsEnabled = driver.FindElement(By.Id("android:id/progress")).Enabled;
            Assert.IsTrue(progressIsEnabled);
            //Check
            bool iconIsEnabled = driver.FindElement(By.Id("android:attr/icon")).Enabled;
            Assert.IsTrue(iconIsEnabled);
            //Check
            bool nameIsEnabled = driver.FindElement(By.Id("android:attr/name")).Enabled;
            Assert.IsTrue(iconIsEnabled);
        }

        [Test, Order(3)]
        public void DialogsProgressBarTest()
        {
            driver.FindElement(By.Id("3. Dialogs")).Click();
            driver.FindElement(By.Id("Show Indeterminate")).Click();
            string expectedTitle = "Indeterminate";
            string actualTitle = driver.FindElement(By.Id("android:id/alertTitle")).Text;
            //Check
            Assert.AreEqual(expectedTitle, actualTitle);
            driver.Navigate().Back();

            driver.FindElement(By.Id("Show Indeterminate No Title")).Click();
            string expectedText = "Please wait while loading...";
            string actualText = driver.FindElement(By.Id("android:id/message")).Text;
            //Check
            Assert.AreEqual(expectedText, actualText);
            //Check
            bool progressBarIsEnabled = driver.FindElement(By.Id("android:id/progress")).Enabled;
            Assert.IsTrue(progressBarIsEnabled);

            driver.Navigate().Back();
        }

        [Test, Order(4)]
        public void TitleProgressBarTest()
        {
            driver.FindElement(By.Id("4. In Title Bar")).Click();

            driver.FindElement(By.Id("io.appium.android.apis:id/toggle")).Click();
            //Check
            bool buttonToggleIsVisible = driver.FindElement(By.Id("io.appium.android.apis:id/toggle")).Displayed;
            bool buttonToggleIsClickable = driver.FindElement(By.Id("io.appium.android.apis:id/toggle")).Enabled;
            Assert.IsTrue(buttonToggleIsVisible);
            Assert.IsTrue(buttonToggleIsClickable);
        }
    }
}