using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace appium
{
    [TestFixture]
    public class Tests: TestRunner
    {

        [Test, Order(1)]
        public void PopupMenu()
        {
            driver.FindElement(By.Id("Views")).Click();
            Thread.Sleep(2000);
            driver.Swipe(750, 1750, 750, 250, 2000);
            driver.Swipe(650, 1750, 650, 500, 2000);
            driver.FindElement(By.Id("Popup Menu")).Click();
            driver.FindElement(By.Id("Make a Popup!")).Click();
            ReadOnlyCollection<AndroidElement> list = driver.FindElements(By.ClassName("android.widget.TextView"));
            for (int i = 0; i < 2; i++)
            {
                list[i].Click();
                driver.FindElement(By.Id("Make a Popup!")).Click();
            }
            list[2].Click();
            driver.FindElement(By.ClassName("android.widget.TextView")).Click();
            Thread.Sleep(2000);
            driver.Navigate().Back();
            driver.Navigate().Back();
        }




        [Test, Order(2)]
        public void ButtonSmall()
        {
            driver.FindElement(By.Id("Views")).Click();
            driver.FindElement(By.Id("Buttons")).Click();
            driver.FindElement(By.Id("Small")).Click();
            driver.Navigate().Back();
        }

        [Test, Order(3)]
        public void ButtonNormal()
        {
            driver.FindElement(By.Id("Buttons")).Click();
            driver.FindElement(By.Id("Normal")).Click();
            driver.Navigate().Back();
        }

        [Test, Order(4)]
        public void ButtonOff()
        {
            driver.FindElement(By.Id("Buttons")).Click();
            driver.FindElement(By.Id("Toggle")).Click();
            driver.Navigate().Back();
        }

        [Test, Order(5)]
        public void ButtonOn()
        {
            driver.FindElement(By.Id("Buttons")).Click();
            driver.FindElement(By.Id("Toggle")).Click();
            driver.Navigate().Back();
        }

        [Test, Order(6)]
        public void ChronometerReset()
        {
            driver.FindElement(By.Id("Chronometer")).Click();
            driver.FindElement(By.Id("Reset")).Click();
            driver.FindElement(By.Id("0 seconds")).Click();
        }

        [Test, Order(7)]
        public void ChronometerStartAndStop()
        {
            driver.FindElement(By.Id("Start")).Click();
            driver.FindElement(By.Id("Stop")).Click();
            driver.FindElement(By.Id("1 seconds")).Click();
        }


       





    }
}
