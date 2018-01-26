using System;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Remote;

namespace AppiumTests
{
    [TestFixture]
    public class UnitTest1
    {
        AppiumDriver<AndroidElement> driver;

        [Test]
        public void TestMethod1()
        {
            const string ipAndPort = "http://127.0.0.1:4723/wd/hub";

            //settings here http://piccy.info/view3/11998164/e853790330ca804685c9a25a18543d0c/orig/

            DesiredCapabilities cap = new DesiredCapabilities();
            cap.SetCapability("platformName", "Android");
            cap.SetCapability("platformVersion", "6.0");
            cap.SetCapability("app", @"C:\Users\Zewer\Desktop\ApiDemos.apk");

            //how to check deviceName. cmd => adb devices -l
            //https://discuss.appium.io/t/how-to-get-device-id/8648/4

            cap.SetCapability("deviceName", "emulator-5554");
            cap.SetCapability("noReset", true);

            driver = new AndroidDriver<AndroidElement>(new Uri(ipAndPort), cap);

            driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(30));

            driver.FindElementByAccessibilityId("Text").Click();
            driver.FindElementByAccessibilityId("LogTextBox").Click();
            driver.FindElementByAccessibilityId("Add").Click();

            Assert.IsTrue(driver.FindElementById("io.appium.android.apis:id/text").GetAttribute("text").Contains("This is a test"));

            //Thread.Sleep(3000);
            driver.Quit();
        }
    }
}
