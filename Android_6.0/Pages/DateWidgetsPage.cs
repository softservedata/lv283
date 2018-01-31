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
	public class DateWidgetsPage: TestRunner
	{
		public DateWidgetsPage(AppiumDriver<AndroidElement> driver)
		{
			this.driver = driver;
			PageFactory.InitElements(driver, this);
		}

		[FindsBy(How = How.Id, Using = "1. Dialog")]
		public IWebElement Dialog { get; protected set; }

		[FindsBy(How = How.Id, Using = "2. Inline")]
		public IWebElement Inline { get; protected set; }

		public DialogPage GoToDialogPage()
		{
			Dialog.Click();
			return new DialogPage(driver);
		}

		public InlinePage GoToInlinePage()
		{
			Inline.Click();
			return new InlinePage(driver);
		}

	}
}
