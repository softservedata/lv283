using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCart.Data.Users;
using OpenCart.Pages.User;
using OpenCart.Tools;

namespace OpenCart.Actions.User
{
	public class LoginAction
	{
		protected LoginPage loginPage = new LoginPage();

		//public MyAccountPage GoToLoginForLoginPageToMyAccountPage(IUser user)
		//{
		//	loginPage.LoginForLoginPageToMyAccountPage(user.GetEmail(), user.GetPassword());
		//	return new MyAccountPage();
		//}

		//public LoginPage GoToLoginForLoginPageToWarning(IUser user)
		//{
		//	loginPage.LoginForLoginPageToWarning(user.GetEmail(), user.GetPassword());
		//	return new LoginPage();
		//}


	}
}
