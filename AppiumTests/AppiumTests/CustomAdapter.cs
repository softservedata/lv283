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
    public class CustomAdapter
    {
        protected AppiumDriver<AndroidElement> driver;

        public CustomAdapter(AppiumDriver<AndroidElement> driver)
        {
            this.driver = driver;
        }

        public bool CheckPeopleNames(List<IName> name)
        {
            driver.FindElementByAccessibilityId("Views").Click();

            driver.FindElementByAccessibilityId("Expandable Lists").Click();
            driver.FindElementByAccessibilityId("1. Custom Adapter").Click();

            driver.FindElementByXPath("//android.widget.ExpandableListView/android.widget.TextView[1]").Click();            

            if (driver.FindElementByXPath("//android.widget.ExpandableListView/android.widget.TextView[2]").GetAttribute("text").Equals(name[0].GetName()))
            {
                name.Reverse();
                if (driver.FindElementByXPath("//android.widget.ExpandableListView/android.widget.TextView[5]").GetAttribute("text").Equals(name[0].GetName()))
                {
                    driver.FindElementByXPath("//android.widget.ExpandableListView/android.widget.TextView[1]").Click();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool CheckDogNames(List<IName> name)
        {
            driver.FindElementByAccessibilityId("Views").Click();
            driver.FindElementByAccessibilityId("Expandable Lists").Click();
            driver.FindElementByAccessibilityId("1. Custom Adapter").Click();

            driver.FindElementByXPath("//android.widget.ExpandableListView/android.widget.TextView[2]").Click();

            if (driver.FindElementByXPath("//android.widget.ExpandableListView/android.widget.TextView[3]").GetAttribute("text").Equals(name[0].GetName()))
            {
                name.Reverse();
                if (driver.FindElementByXPath("//android.widget.ExpandableListView/android.widget.TextView[6]").GetAttribute("text").Equals(name[0].GetName()))
                {
                    driver.FindElementByXPath("//android.widget.ExpandableListView/android.widget.TextView[2]").Click();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool CheckCatNames(List<IName> name)
        {
            driver.FindElementByAccessibilityId("Views").Click();
            driver.FindElementByAccessibilityId("Expandable Lists").Click();
            driver.FindElementByAccessibilityId("1. Custom Adapter").Click();

            driver.FindElementByXPath("//android.widget.ExpandableListView/android.widget.TextView[3]").Click();

            if (driver.FindElementByXPath("//android.widget.ExpandableListView/android.widget.TextView[4]").GetAttribute("text").Equals(name[0].GetName()))
            {
                name.Reverse();
                if (driver.FindElementByXPath("//android.widget.ExpandableListView/android.widget.TextView[5]").GetAttribute("text").Equals(name[0].GetName()))
                {
                    driver.FindElementByXPath("//android.widget.ExpandableListView/android.widget.TextView[3]").Click();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool CheckFishNames(List<IName> name)
        {
            driver.FindElementByAccessibilityId("Views").Click();
            driver.FindElementByAccessibilityId("Expandable Lists").Click();
            driver.FindElementByAccessibilityId("1. Custom Adapter").Click();

            driver.FindElementByXPath("//android.widget.ExpandableListView/android.widget.TextView[4]").Click();

            if (driver.FindElementByXPath("//android.widget.ExpandableListView/android.widget.TextView[5]").GetAttribute("text").Equals(name[0].GetName()))
            {
                name.Reverse();
                if (driver.FindElementByXPath("//android.widget.ExpandableListView/android.widget.TextView[6]").GetAttribute("text").Equals(name[0].GetName()))
                {
                    driver.FindElementByXPath("//android.widget.ExpandableListView/android.widget.TextView[4]").Click();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
