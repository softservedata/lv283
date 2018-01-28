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
using Android_6._0.Pages;

namespace Android_6._0
{
	[TestFixture]
	public class AndroidTest:TestRunner
	{
		[Test, Order(1)]
		public void CheckAppiumAndroid()
		{
			HomePage home = new HomePage(driver);
			ViewsPage views = home.GoToViewsPage();
			RadioGroupPage radioGroupPage = views.GoToRadioGroupPage();
			Thread.Sleep(1000);
			radioGroupPage.RadioSnack.Click();
			radioGroupPage.CheckRadioGroup("2131296259");
			Thread.Sleep(1000);
			radioGroupPage.RadioBreakfast.Click();
			radioGroupPage.CheckRadioGroup("2131296533");
			Thread.Sleep(1000);
			radioGroupPage.RadioLunch.Click();
			radioGroupPage.CheckRadioGroup("2131296531");
			Thread.Sleep(1000);
			radioGroupPage.RadioDinner.Click();
			radioGroupPage.CheckRadioGroup("2131296534");
			Thread.Sleep(1000);
			radioGroupPage.RadioAll.Click();
			radioGroupPage.CheckRadioGroup("2131296535");
			Thread.Sleep(1000);
			radioGroupPage.ButtonClear.Click();
			radioGroupPage.CheckRadioGroup("(none)");
			Thread.Sleep(1000);
			
		}

	}
}
