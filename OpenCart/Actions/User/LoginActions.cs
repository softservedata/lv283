using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCart.Data.Users;
using OpenCart.Pages.User;

namespace OpenCart.Actions.User
{
	public class LoginActions : ColumnRightActions
	{
		public LoginPage LoginAccountPageOperation { get; private set; }

		public LoginActions()
		{
			LoginAccountPageOperation = new LoginPage();
		}

		public MyAccountActions UnsuccessfulLogin(IUser invalidUser)
		{
			LoginAccountPageOperation.LoginUser(invalidUser);
			return new MyAccountActions();
		}

		public MyAccountActions SuccessfulLogin(IUser validUser)
		{
			LoginAccountPageOperation.LoginUser(validUser);
			return new MyAccountActions();
		}


	}
}
