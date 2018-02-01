using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.PageObjects;
using System.Threading;

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

		[FindsBy(How = How.XPath, Using = "	/hierarchy/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.LinearLayout/android.widget.Button[2]")]
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


		public void CheckRadioGroup(string idText)
		{
			Assert.IsTrue(DateDisplay.Text.Contains(idText));
			
		}

		public void Check(string hour, string minutes)
		{
			string time = hour + ":" + minutes;
			Assert.IsTrue(DateDisplay.Text.Substring(DateDisplay.Text.Length - 5, DateDisplay.Text.Length).Contains(time));
		}

		public void CheckWidgetsTime(string hour, string minutes)
		{
			Assert.IsTrue(Hours.Text.Contains(hour));
			Assert.IsTrue(Minutes.Text.Contains(minutes));
		}

		public void GhangeTime(string hour, string minutes)
		{
			ChangeTime.Click();
			Am.Click();
			Thread.Sleep(1000);
			Hours.Click();
			Thread.Sleep(3000);
			driver.FindElementById(hour).Click();
			Thread.Sleep(3000);
			driver.FindElementById(minutes).Click();
			Thread.Sleep(3000);
			Check(hour, minutes);
			Thread.Sleep(3000);
		}

		public void GhangeWidgetsTime(string hour, string minutes)
		{
			//GhangeTime(hour, minutes);
			Thread.Sleep(3000);
			CheckWidgetsTime(hour, minutes);
		}


	}
}
