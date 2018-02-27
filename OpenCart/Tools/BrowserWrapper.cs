using System;
using System.IO;
using System.Drawing.Imaging;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenCart.Data;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;

namespace OpenCart.Tools
{
    public class BrowserWrapper
    {
        private interface IBrowser
        {
            IWebDriver GetBrowser(ApplicationSource applicationSource);
        }

        private class FirefoxTemporary : IBrowser
        {
            public IWebDriver GetBrowser(ApplicationSource applicationSource)
            {
                return new FirefoxDriver();
            }
        }

        private class ChromeTemporary : IBrowser
        {
            public IWebDriver GetBrowser(ApplicationSource applicationSource)
            {
            return new ChromeDriver();
            }
        }

        private class ChromeWithoutUI : IBrowser
        {
            public IWebDriver GetBrowser(ApplicationSource applicationSource)
            {
                //options.addArguments("--headless");
                ChromeOptions options = new ChromeOptions();
                //options.AddArguments("--start-maximized");
                options.AddArguments("--no-proxy-server");
                //options.AddArguments("--no-sandbox");
                //options.AddArguments("--disable-web-security");
                options.AddArguments("--ignore-certificate-errors");
                //options.AddArguments("--disable-extensions");
                options.AddArguments("--headless");
                //options.BinaryLocation = @"C:\...\ChromiumPortable.exe";
                return new ChromeDriver(options); ;
            }
        }

        // Fields
        private Dictionary<string, IBrowser> Browsers;
        public IWebDriver Driver { get; private set; }

        public BrowserWrapper(ApplicationSource applicationSource)
        {
            InitDictionary();
            InitWebDriver(applicationSource);
        }

        private void InitDictionary()
        {
            Browsers = new Dictionary<string, IBrowser>();
            Browsers.Add("DefaultTemporary", new ChromeTemporary());
            Browsers.Add("FirefoxTemporary", new FirefoxTemporary());
            Browsers.Add("ChromeTemporary", new ChromeTemporary());
            Browsers.Add("ChromeWithoutUI", new ChromeWithoutUI());
        }

        private void InitWebDriver(ApplicationSource applicationSource)
        {
            IBrowser currentBrowser = Browsers["DefaultTemporary"];
            foreach (KeyValuePair<string, IBrowser> current in Browsers)
            {
                if (current.Key.ToString().ToLower().Contains(applicationSource.BrowserName.ToLower()))
                {
                    currentBrowser = current.Value;
                    break;
                }
            }
            Driver = currentBrowser.GetBrowser(applicationSource);
            // TODO Move to Search Class
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

		private string GetTime()
		{
			DateTime localDate = DateTime.Now;
			return localDate.ToString("yyyy_MM_dd_HH_mm_ss");
		}

		private string GetCurrentDirectory()
		{
            return Path.GetDirectoryName(Assembly.GetAssembly(typeof(BrowserWrapper)).CodeBase).Substring(6);
		}

		public string SaveScreenshot()
		{
			return SaveScreenshot(null);
		}

		public string SaveScreenshot(string namePrefix)
		{
			if ((namePrefix == null) || (namePrefix.Length == 0))
			{
				namePrefix = GetTime();
			}
            ITakesScreenshot takesScreenshot = Driver as ITakesScreenshot;
			Screenshot screenshot = takesScreenshot.GetScreenshot();
			screenshot.SaveAsFile(GetCurrentDirectory() + "\\" + namePrefix + "_Screenshot.png",
				ScreenshotImageFormat.Png);
			return namePrefix;
		}

		public string SaveSourceCode()
		{
			return SaveSourceCode(null);
		}
		public string SaveSourceCode(string namePrefix)
		{
			if ((namePrefix == null) || (namePrefix.Length == 0))
			{
				namePrefix = GetTime();
			}
			File.WriteAllText(GetCurrentDirectory() + "\\" + namePrefix + "_SourceCode.txt", Driver.PageSource);
			return namePrefix;
		}

		public void OpenUrl(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }

        public void NavigateForward()
        {
            Driver.Navigate().Forward();
        }

        public void NavigateBack()
        {
            Driver.Navigate().Back();
        }

        public void RefreshPage()
        {
            Driver.Navigate().Refresh();
        }

        public void Quit()
        {
            if (Driver != null)
            {
                Driver.Quit();
                Driver = null;
            }
        }

    }
}
