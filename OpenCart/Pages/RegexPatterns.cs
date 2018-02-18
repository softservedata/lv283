using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart.Pages
{
	public class RegexPatterns
	{
		public const string ALL_DIGITS = "\\d+";

	    public const string FIRST_DIGITS = "^\\d+";

		public const string LAST_DOUBLE = "\\d+\\.\\d+$";

		public const string NUMBER_DOUBLE = "\\d+\\.\\d+";

		public const string PRICE_SYMBOL = "[€\\£\\$]";
	}
}
