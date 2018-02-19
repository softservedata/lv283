using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCart.Data;
using OpenCart.Actions.User;
using OpenCart.Tools;
using OpenCart.Pages.User;

namespace OpenCart.Pages
{
	public class Application
	{
		private volatile static Application instance;
		private static object lockingObject = new object();

		// TODO Change for parallel work
		public ApplicationSource ApplicationSource { get; private set; }
		//public FlexAssert FlexAssert { get; private set; }
		public BrowserWrapper Browser { get; private set; }


		public ISearch Search { get; private set; }

		private Application(ApplicationSource applicationSource)
		{
			this.ApplicationSource = applicationSource;
		}

		public static Application Get()
		{
			return Get(null);
		}

		public static Application Get(ApplicationSource applicationSource)
		{
			if (instance == null)
			{
				lock (lockingObject)
				{
					if (instance == null)
					{
						if (applicationSource == null)
						{
							applicationSource = ApplicationSourceRepository.Default();
						}
						instance = new Application(applicationSource);
						//
						instance.InitBrowser(applicationSource);
						instance.InitSearch(applicationSource);
					}
				}
			}
			return instance;
		}

		public static void Remove()
		{
			if (instance != null)
			{
				// TODO Change for parallel work
				instance.Browser.Quit();
				instance = null;
			}
		}

		private void InitBrowser(ApplicationSource applicationSource)
		{
			this.Browser = new BrowserWrapper(applicationSource);
		}

		private void InitSearch(ApplicationSource applicationSource)
		{
			this.Search = new SearchElement(applicationSource);
		}

		public HomeActions LoadHomeActions()
		{
			Browser.OpenUrl(ApplicationSource.BaseUrl);
			return new HomeActions();
		}

		public LoginAccountActions LoadLoginAccountActions()
		{
			Browser.OpenUrl(ApplicationSource.BaseUrl);
			return new LoginAccountActions();
		}

		public LoginPage Login()
		{
			Browser.OpenUrl(ApplicationSource.BaseUrl);
			//return new LoginPage(getBrowser().getDriver());
			return new LoginPage();
		}

	}
}


