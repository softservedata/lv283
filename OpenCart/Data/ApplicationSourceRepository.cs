using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart.Data
{
	public sealed class ApplicationSourceRepository
	{
		private ApplicationSourceRepository() { }

		public static ApplicationSource Default()
		{
			return ChromeEpizy();
		}

		public static ApplicationSource FirefoxEpizy()
		{
			return new ApplicationSource("FirefoxTemporary", 10L,
				"http://283-taqc.ml/?i=1",
				"http://atqc-shop.epizy.com/index.php?route=account/logout",
				"http://atqc-shop.epizy.com/admin/");
		}

		public static ApplicationSource ChromeEpizy()
		{
			return new ApplicationSource("ChromeTemporary", 10L,
				"http://283-taqc.ml/?i=1",
				"http://283-taqc.ml/index.php?route=account/account",
				"http://atqc-shop.epizy.com/admin/");
		}

		public static ApplicationSource ChromeWithoutUIEpizy()
		{
			return new ApplicationSource("ChromeWithoutUI", 10L,
				"http://283-taqc.ml/?i=1",
				"http://atqc-shop.epizy.com/index.php?route=account/logout",
				"http://atqc-shop.epizy.com/admin/");
		}


	}
}