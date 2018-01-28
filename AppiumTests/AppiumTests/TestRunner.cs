using System;
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
using OpenQA.Selenium.Interactions;

namespace AppiumTests
{
    public abstract class TestRunner
    {
        protected AppiumDriver<AndroidElement> driver;

        [OneTimeSetUp]
        public void BeforeAllMethods()
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

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
        }

        [OneTimeTearDown]
        public void AfterAllMethods()
        {
            driver.Quit();
        }

        //[SetUp]
        public void BeforeTest()
        {
            //driver.ResetApp();
        }

        [TearDown]
        public void AfterTest()
        {
            driver.ResetApp();
        }
    }
}
