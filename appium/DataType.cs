using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using System;

namespace appium
{
    [TestFixture]
    public class DataType: Data
    {
        [Test, Order(1)]
        public void Datatype()
        {
            driver.ResetApp();
            driver.FindElement(By.Id("Content")).Click();
            driver.FindElement(By.Id("Clipboard")).Click();
            driver.FindElement(By.Id("Data Types")).Click();
        }


        [Test, Order(2), TestCaseSource(nameof(Data.copyText))]
        public void CopyText(string button, string name)
        {
            driver.FindElement(By.Id(button)).Click();
            string message1 = driver.FindElement(By.Id(name)).Text;
            string message2 = driver.FindElement(By.Id("io.appium.android.apis:id/clip_text")).Text;
            Assert.AreEqual(message1, message2);
        }

        [Test, Order(3)]
        public void CopyIntent()
        {
            driver.FindElement(By.Id("Copy Intent")).Click();
            Assert.AreEqual("Intent clip", driver.FindElement(By.Id("android:id/text1")).Text);
            Assert.AreEqual("text/vnd.android.intent", driver.FindElement(By.Id("io.appium.android.apis:id/clip_mime_types")).Text);
            Assert.AreEqual("http://www.android.com/", driver.FindElement(By.Id("io.appium.android.apis:id/clip_text")).Text);

        }

        [Test, Order(4)]
        public void CopyUri()
        {
            driver.FindElement(By.Id("Copy URI")).Click();
            Assert.AreEqual("Uri clip", driver.FindElement(By.Id("android:id/text1")).Text);
            Assert.AreEqual("text/uri-list", driver.FindElement(By.Id("io.appium.android.apis:id/clip_mime_types")).Text);
            Assert.AreEqual("http://www.android.com/", driver.FindElement(By.Id("io.appium.android.apis:id/clip_text")).Text);

        }
    }
}
