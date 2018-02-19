using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCart.Data.Users;
using OpenCart.Pages.User;

namespace OpenCart.Actions.User
{
	public class MyAccountActions : AColumnRightUserComponent 
	{
		public MyAccountPage MyAccountPageOperation { get; private set; }

		public MyAccountActions()
		{
			MyAccountPageOperation = new MyAccountPage();
		}
	}
}
