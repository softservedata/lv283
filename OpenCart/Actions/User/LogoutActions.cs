using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCart.Pages.User;

namespace OpenCart.Actions.User
{
	public class LogoutActions : ColumnRightActions
	{
		public LogoutPage LogoutPageOperation { get; private set; }

		public LogoutActions()
		{
			LogoutPageOperation = new LogoutPage();
		}

	}
}
