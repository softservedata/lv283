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
using AppiumTests.Data.Names;

namespace AppiumTests
{
    public class View
    {
        protected AppiumDriver<AndroidElement> driver;

        public View(AppiumDriver<AndroidElement> driver)
        {
            this.driver = driver;
        }

        public bool CustomAdapterNames(List<IName> name)
        {
            driver.FindElementByAccessibilityId("Views").Click();

            driver.FindElementByAccessibilityId("Expandable Lists").Click();
            driver.FindElementByAccessibilityId("1. Custom Adapter").Click();

            driver.FindElementByXPath("//android.widget.ExpandableListView/android.widget.TextView[1]").Click();
            //Assert.IsTrue(driver.FindElementByXPath("//android.widget.ExpandableListView/android.widget.TextView[2]").GetAttribute("text").Contains("Arnold"));
            Assert.IsTrue(driver.FindElementByXPath("//android.widget.ExpandableListView/android.widget.TextView[2]").GetAttribute("text").Contains(name[0].GetName()));

            //Assert.IsTrue(driver.FindElementByXPath("//android.widget.ExpandableListView/android.widget.TextView[5]").GetAttribute("text").Contains("David"));
            Assert.IsTrue(driver.FindElementByXPath("//android.widget.ExpandableListView/android.widget.TextView[5]").GetAttribute("text").Contains(name[1].GetName()));

            driver.FindElementByXPath("//android.widget.ExpandableListView/android.widget.TextView[6]").Click();
            Assert.IsTrue(driver.FindElementByXPath("//android.widget.ExpandableListView/android.widget.TextView[7]").GetAttribute("text").Contains("Ace"));
            Assert.IsTrue(driver.FindElementByXPath("//android.widget.ExpandableListView/android.widget.TextView[10]").GetAttribute("text").Contains("Deuce"));

            driver.FindElementByXPath("//android.widget.ExpandableListView/android.widget.TextView[11]").Click();
            Assert.IsTrue(driver.FindElementByXPath("//android.widget.ExpandableListView/android.widget.TextView[12]").GetAttribute("text").Contains("Fluffy"));
            Assert.IsTrue(driver.FindElementByXPath("//android.widget.ExpandableListView/android.widget.TextView[13]").GetAttribute("text").Contains("Snuggles"));

            driver.FindElementByXPath("//android.widget.ExpandableListView/android.widget.TextView[14]").Click();
            Assert.IsTrue(driver.FindElementByXPath("//android.widget.ExpandableListView/android.widget.TextView[15]").GetAttribute("text").Contains("Goldy"));
            Assert.IsTrue(driver.FindElementByXPath("//android.widget.ExpandableListView/android.widget.TextView[16]").GetAttribute("text").Contains("Bubbles"));

            driver.FindElementByXPath("//android.widget.ExpandableListView/android.widget.TextView[14]").Click();
            driver.FindElementByXPath("//android.widget.ExpandableListView/android.widget.TextView[11]").Click();
            driver.FindElementByXPath("//android.widget.ExpandableListView/android.widget.TextView[6]").Click();
            driver.FindElementByXPath("//android.widget.ExpandableListView/android.widget.TextView[1]").Click();

            return driver.FindElementByXPath("//android.widget.ExpandableListView/android.widget.TextView[1]").GetAttribute("text").Contains("People Names");
        }
    }
}
