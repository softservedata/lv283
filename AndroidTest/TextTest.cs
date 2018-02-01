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
        //[Test]
        public void LinkifyTest()
        {

        }

        [Test, Order(1)]
        public void LogTextBoxTestAdd()
        {
            driver.FindElement(By.Id("Text")).Click();
            string expectedText = "This is a test\r\n";
            driver.FindElement(By.Id("LogTextBox")).Click();
            driver.FindElement(By.Id("Add")).Click();
            string actualText = driver.FindElement(By.Id("io.appium.android.apis:id/text")).Text;
            Assert.AreEqual(expectedText, actualText);
            driver.Navigate().Back();
            driver.Navigate().Back();
        }

        private static readonly object[] DatesData =
        {
            new object[] { DateRepository.Get().Christmass() }
		};

        [Test, Order(2), TestCaseSource(nameof(DatesData))]
        public void DateWidgetsTest(IDate date)
        {
            driver.FindElement(By.Id("Views")).Click();
            driver.FindElement(By.Id("Date Widgets")).Click();
            driver.FindElement(By.Id("1. Dialog")).Click();
            string currentDate = driver.FindElement(By.Id("io.appium.android.apis:id/dateDisplay")).Text;
            Console.WriteLine(currentDate);
            DateTime dt = Convert.ToDateTime(currentDate);
            Console.WriteLine(dt.Year);
            driver.FindElement(By.Id("change the date")).Click();
            driver.FindElement(By.Id("android:id/date_picker_header_year"));
            driver.FindElement(By.ClassName("android.widget.TextView")).Click();
            Console.WriteLine(date.ToString());
            driver.FindElement(By.XPath("/hierarchy/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.DatePicker/android.widget.LinearLayout/android.widget.ViewAnimator/android.widget.ListView/android.widget.TextView[6]")).Click();
        }
    }
}
