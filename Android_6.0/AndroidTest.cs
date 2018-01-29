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
using Android_6._0.Data.RadioGroups;

namespace Android_6._0
{
	[TestFixture]
	public class AndroidTest:TestRunner
	{

		private static readonly object[] RadioGroupData =
		{
			new object[] { RadioGroupRepository.Get().Group() }
			//new object[] { RadioGroupRepository.Get().Breakfast() },
			//new object[] { RadioGroupRepository.Get().Lunch() },
			//new object[] { RadioGroupRepository.Get().Dinner() },
			//new object[] { RadioGroupRepository.Get().AllOfThem() },
			//new object[] { RadioGroupRepository.Get().None() }
		};

		[Test, Order(1), TestCaseSource(nameof(RadioGroupData))]
		public void CheckAppiumAndroid(IRadioGroup radioGroup)
		{
			HomePage home = new HomePage(driver);
			ViewsPage views = home.GoToViewsPage();
			RadioGroupPage radioGroupPage = views.GoToRadioGroupPage();
			Thread.Sleep(1000);
			radioGroupPage.RadioSnack.Click();			
			radioGroupPage.CheckRadioGroup(radioGroup.GetSnack());
			Thread.Sleep(1000);
			radioGroupPage.RadioBreakfast.Click();
			radioGroupPage.CheckRadioGroup(radioGroup.GetBreakfast());
			Thread.Sleep(1000);
			radioGroupPage.RadioLunch.Click();
			radioGroupPage.CheckRadioGroup(radioGroup.GetLunch());
			Thread.Sleep(1000);
			radioGroupPage.RadioDinner.Click();
			radioGroupPage.CheckRadioGroup(radioGroup.GetDinner());
			Thread.Sleep(1000);
			radioGroupPage.RadioAll.Click();
			radioGroupPage.CheckRadioGroup(radioGroup.GetAll());
			Thread.Sleep(1000);
			radioGroupPage.ButtonClear.Click();
			radioGroupPage.CheckRadioGroup(radioGroup.GetClear());
			Thread.Sleep(1000);
		}


	}
}
