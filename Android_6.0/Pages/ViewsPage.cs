using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.PageObjects;

namespace Android_6._0.Pages
{
	public class ViewsPage: TestRunner
	{
		public ViewsPage(AppiumDriver<AndroidElement> driver)
		{
			this.driver = driver;
			PageFactory.InitElements(driver, this);
		}

		[FindsBy(How = How.Id, Using = "Radio Group")]
		public IWebElement RadioGroup { get; protected set; }


		[FindsBy(How = How.Id, Using = "Date Widgets")]
		public IWebElement DateWidgets { get; protected set; }

		public RadioGroupPage GoToRadioGroupPage()
		{
			//
			Thread.Sleep(1000);
			driver.Swipe(650, 1700, 650, 250, 2000);
			Thread.Sleep(1000);
			driver.Swipe(650, 1750, 650, 1400, 2000);
			Thread.Sleep(1000);
			//
			RadioGroup.Click();
			return new RadioGroupPage(driver);
		}

		public DateWidgetsPage GoToDateWidgetsPage()
		{
			//
			DateWidgets.Click();
			return new DateWidgetsPage(driver);
		}

	}
}
