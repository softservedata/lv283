using System;
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
using OpenQA.Selenium.Support.PageObjects;

namespace Android_6._0.Pages
{
	public class RadioGroupPage: TestRunner
	{
		public RadioGroupPage(AppiumDriver<AndroidElement> driver)
		{
			this.driver = driver;
			PageFactory.InitElements(driver, this);
		}

		[FindsBy(How = How.Id, Using = "io.appium.android.apis:id/snack")]
		public IWebElement RadioSnack { get; protected set; }

		[FindsBy(How = How.Id, Using = "io.appium.android.apis:id/breakfast")]
		public IWebElement RadioBreakfast { get; protected set; }

		[FindsBy(How = How.Id, Using = "io.appium.android.apis:id/lunch")]
		public IWebElement RadioLunch { get; protected set; }

		[FindsBy(How = How.Id, Using = "io.appium.android.apis:id/dinner")]
		public IWebElement RadioDinner { get; protected set; }

		[FindsBy(How = How.Id, Using = "io.appium.android.apis:id/all")]
		public IWebElement RadioAll { get; protected set; }

		[FindsBy(How = How.Id, Using = "io.appium.android.apis:id/clear")]
		public IWebElement ButtonClear { get; protected set; }

		[FindsBy(How = How.Id, Using = "io.appium.android.apis:id/choice")]
		public IWebElement Actual { get; protected set; }


		public void CheckRadioGroup(string idText)
		{
			Assert.IsTrue(Actual.GetAttribute("text").Contains(idText));
		}

	}
}
