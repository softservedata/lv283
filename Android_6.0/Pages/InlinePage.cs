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
	public class InlinePage : TestRunner
	{
		public InlinePage(AppiumDriver<AndroidElement> driver)
		{
			this.driver = driver;
			PageFactory.InitElements(driver, this);
		}

		[FindsBy(How = How.Id, Using = "android:id/hours")]
		public IWebElement Hours { get; protected set; }

		[FindsBy(How = How.Id, Using = "android:id/minutes")]
		public IWebElement Minutes { get; protected set; }

		[FindsBy(How = How.Id, Using = "android:id/am_label")]
		public IWebElement Am { get; protected set; }

		[FindsBy(How = How.Id, Using = "android:id/pm_label")]
		public IWebElement Pm { get; protected set; }

		public void Check(string h, string m)
		{
			Assert.IsTrue(Hours.Text.Contains(h));
			Assert.IsTrue(Minutes.Text.Contains(m));
		}

		public void GhangeTime(string h, string m)
		{
			Am.Click();
			Hours.Click();
			Thread.Sleep(1000);
			driver.FindElementById(h).Click();
			Thread.Sleep(1000);
			driver.FindElementById(m).Click();
			Thread.Sleep(1000);
			Check(h, m);
		}








	}
}
