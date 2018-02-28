using OpenCart.Data;
using OpenCart.Actions.User;
using OpenCart.Tools;
using NLog;
using OpenCart.Pages.User;

namespace OpenCart.Pages
{
	public class Application
	{
		private volatile static Application instance;
		private static object lockingObject = new object();
		private static Logger log = LogManager.GetCurrentClassLogger();

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
			log.Debug("Start LoadHomeActions()");
			Browser.OpenUrl(ApplicationSource.BaseUrl);
			return new HomeActions();
		}

		public LogoutActions LogoutAction()
		{
			Browser.OpenUrl(ApplicationSource.UserLogoutUrl);
            MyAccountOptions.IsLoggedin = false;
			return new LogoutActions();
		}

		public void SaveCurrentState()
		{
			log.Warn("Saved Current State");
			string prefix = Browser.SaveScreenshot();
			Browser.SaveSourceCode(prefix);
		}
	}
}


