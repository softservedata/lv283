using System;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Remote;

namespace Android_6._0
{
	public class TestRunner
	{

		protected AppiumDriver<AndroidElement> driver;
		protected AndroidElement wait;
		protected AndroidElement actual;

		private readonly string url = @"D:\ATQC\TAQC.NET\ApiDemos.apk";
		private readonly string uri = @"http://127.0.0.1:4723/wd/hub";

		[OneTimeSetUp]
		public void BeforeAllMethods()
		{
			DesiredCapabilities capabilities = new DesiredCapabilities();
			//
			capabilities.SetCapability(MobileCapabilityType.App, url);
			capabilities.SetCapability(MobileCapabilityType.DeviceName, "emulator-5554");
			capabilities.SetCapability(MobileCapabilityType.Udid, "emulator-5554");
			capabilities.SetCapability(MobileCapabilityType.PlatformVersion, "6.0.0");
			capabilities.SetCapability(MobileCapabilityType.PlatformName, "Android");
			capabilities.SetCapability(MobileCapabilityType.FullReset, "false");
			//
			driver = new AndroidDriver<AndroidElement>(new Uri(uri), capabilities);
		}

		[OneTimeTearDown]
		public void AfterAllMethods()
		{
			driver.CloseApp();
		}

		

		[SetUp]
		public void BeforeTest()
		{
			//driver.Navigate().GoToUrl(url);
			//LoginUser(user);
		}

		[SetUp]
		public void AfterTest()
		{
			//LogoutUser();
		}
	}
}
