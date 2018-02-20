using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCart.Data.Users;
using OpenCart.Pages.User;

namespace OpenCart.Actions.User
{
	public class RegisterActions
	{
		public RegisterAccountPage RegisterAccountPageOperation { get; private set; }

		public RegisterActions()
		{
			RegisterAccountPageOperation = new RegisterAccountPage();
		}

		public RegisterActions UnsuccessfulRegister(IUser invalidUser)
		{
			RegisterAccountPageOperation.RegisterUser(invalidUser);
			return new RegisterActions();
		}

		//public MyAccountActions SuccessfulRegister(IUser validUser)
		//{
		//    RegisterAccountPageOperation.RegisterUser(validUser);
		//    return new MyAccountActions();
		//}
	}
}
