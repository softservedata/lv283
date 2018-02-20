using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenCart.Actions.User;
using OpenCart.Pages;
using OpenCart.Data;
using Reporter;


namespace OpenCart.Tools
{
	public class ReporterWrapper
	{
		// ReporterTags
		public const string BR_DISPLAY = "<br>[DISPLAY]";

		public const string BR_ERROR = "<br>[ERROR]";

		public const string BR_WARNING = "<br>[WARNING]";

		public const string BR_INFO = "<br>[INFO]";

		public const string BR_DEBUG = "<br>[DEBUG]";

		// ReporterLevels
		public const string ERROR_LEVEL = "2";

	    public const string WARNING_LEVEL = "5";

		public const string INFO_LEVEL = "7";

		public const string DEBUG_LEVEL = "9";

		//

		public const string IMG_TEMPLATE = "<br><div><image style=\"max-width:90%%\" src=\"%s\"  alt=\"could not take screen shot\" /></div>";

		public const string SCREENSHOT_FILENAME = "<br><p>Screenshot filename is %s</p>";

		public const string SOURCECODE_FILENAME = "<br><p><a href='%s'>Source Code</a> filename is %s</p>";

		public const string SPACE_SYMBOL = " ";


		public ReporterWrapper()
		{
		}






	}
}
