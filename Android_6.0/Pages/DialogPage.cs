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
	public class DialogPage: TestRunner
	{
		public DialogPage(AppiumDriver<AndroidElement> driver)
		{
			this.driver = driver;
			PageFactory.InitElements(driver, this);
		}

		[FindsBy(How = How.Id, Using = "io.appium.android.apis:id/dateDisplay")]
		public IWebElement DateDisplay { get; protected set; }

		[FindsBy(How = How.Id, Using = "change the date")]
		public IWebElement ChangeDate { get; protected set; }

		[FindsBy(How = How.Id, Using = "change the time")]
		public IWebElement ChangeTime { get; protected set; }

		[FindsBy(How = How.Id, Using = "android:id/date_picker_header_year")]
		public IWebElement DisplayYear { get; protected set; }

		[FindsBy(How = How.Id, Using = "android:id/date_picker_header_date")]
		public IWebElement DisplayDate { get; protected set; }

		[FindsBy(How = How.Id, Using = "android:id/button1")]
		public IWebElement OK { get; protected set; }

		[FindsBy(How = How.Id, Using = "android:id/button2")]
		public IWebElement Cancel { get; protected set; }


		[FindsBy(How = How.Id, Using = "Previous month")]
		public IWebElement PreviousMonth { get; protected set; }

		[FindsBy(How = How.Id, Using = "Next month")]
		public IWebElement NextMonth { get; protected set; }

		[FindsBy(How = How.Id, Using = "31 December 2017")]
		public IWebElement Date { get; protected set; }


		/// <summary>
		/// ///////////////////////////Time
		/// </summary>
		[FindsBy(How = How.Id, Using = "android:id/hours")]
		public IWebElement Hours { get; protected set; }

		[FindsBy(How = How.Id, Using = "android:id/minutes")]
		public IWebElement Minutes { get; protected set; }

		[FindsBy(How = How.Id, Using = "android:id/am_label")]
		public IWebElement Am { get; protected set; }

		[FindsBy(How = How.Id, Using = "android:id/pm_label")]
		public IWebElement Pm { get; protected set; }


		public string idHourse = "1";
		[FindsBy(How = How.Id, Using = "1")]
		public IWebElement IdHours { get; protected set; }

		public string idMinutes = "05";
		[FindsBy(How = How.Id, Using = "05")]
		public IWebElement IdMinutes { get; protected set; }



		public void GoToChangeDate(string year)
		{
			if (DisplayYear.Text.Contains(year))
			{

			}
			else
			{

			}
		}

		public void GoToGhangeAMTime(string h, string m)
		{
			Am.Click();
			Hours.Click();
			IdHours.FindElement(By.Id(h)).Click();
			//IdHours.Click();
			IdMinutes.FindElement(By.Id(m)).Click();
			//IdMinutes.Click();
			OK.Click();
		}
		public void GoToGhangePMTime()
		{
			Pm.Click();
			Hours.Click();
			IdHours.Click();
			IdMinutes.Click();
			OK.Click();
		}

		public void CheckRadioGroup(string idText)
		{
			Assert.IsTrue(DateDisplay.Text.Contains(idText));
		}

	}
}
