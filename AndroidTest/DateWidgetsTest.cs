using AndroidTest.Data.Dates;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Globalization;

namespace AndroidTest
{
    public class DateWidgetsTest : TestRunner
    {

        private static readonly object[] DatesData =
        {
            new object[] { DateRepository.Get().ValentinesDay() }
        };

        [Test, TestCaseSource(nameof(DatesData))]
        public void VerifyDateChanging(IDate date)
        {
            driver.FindElement(By.Id("Views")).Click();
            driver.FindElement(By.Id("Date Widgets")).Click();
            driver.FindElement(By.Id("1. Dialog")).Click();
            driver.FindElement(By.Id("change the date")).Click();

            driver.FindElement(By.Id("android:id/date_picker_header_year")).Click();
            driver.FindElement(By.XPath("/hierarchy/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.DatePicker/android.widget.LinearLayout/android.widget.ViewAnimator/android.widget.ListView/android.widget.TextView[@text = \"" + date.GetYear() + "\"]")).Click();
            driver.FindElement(By.Id(date.GetDay() + " " + date.GetMonth() + " " + date.GetYear())).Click();
            driver.FindElement(By.Id("android:id/button1")).Click();
            string actualDateString = driver.FindElement(By.Id("io.appium.android.apis:id/dateDisplay")).Text;
            
            DateTime actualDate = DateTime.ParseExact(
                    driver.FindElement(By.Id("io.appium.android.apis:id/dateDisplay")).Text,
                    "M-d-yyyy HH:mm",
                    CultureInfo.InvariantCulture);
            Assert.AreEqual(date.ToString(), actualDate.ToString("M-d-yyyy"));
        }

    }
}
