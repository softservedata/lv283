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
using System;
using System.Globalization;
using AndroidTest.Data.Dates;

namespace AndroidTest
{
    [TestFixture]
    public class TextTest : TestRunner
    {
        
        [Test]
        public void VerifyAddingTextLogTextBox()
        {
            driver.FindElement(By.Id("Text")).Click();
            driver.FindElement(By.Id("LogTextBox")).Click();
            driver.FindElement(By.Id("Add")).Click();

            string expectedText = "This is a test\r\n";
            string actualText = driver.FindElement(By.Id("io.appium.android.apis:id/text")).Text;

            Assert.AreEqual(expectedText, actualText);
        }

        private static readonly object[] ButtonsToClick =
        {
            new object[] { "This use the default marquee animation limit of 3" },
            new object[] { "This will run the marquee animation once" },
            new object[] { "This will run the marquee animation forever" }
        };

        [Test, TestCaseSource(nameof(ButtonsToClick))]
        public void ClickMarqueeButtons(string buttonId)
        {
            driver.FindElement(By.Id("Text")).Click();
            driver.FindElement(By.Id("Marquee")).Click();

            driver.FindElement(By.Id(buttonId)).Click();
        }
    }
}
