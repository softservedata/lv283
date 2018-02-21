using OpenCart.Data.Users;
using OpenCart.Pages.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart.Actions.User
{
	public class EditPasswordActions : ColumnRightActions
	{
		public EditPasswordPage EditPasswordPageOperation { get; private set; }

		public EditPasswordActions() : base()
		{
			EditPasswordPageOperation = new EditPasswordPage();
		}

		public EditPasswordActions UnsuccessfulChangePassword(Data.Passwords.IPassword invalidPassword)
		{
			EditPasswordPageOperation.ChangePassword(invalidPassword);
			return new EditPasswordActions();
		}

		public EditPasswordActions SuccessfulChangePassword(Data.Passwords.IPassword validPassword)
		{
			EditPasswordPageOperation.ChangePassword(validPassword);
			return new EditPasswordActions();
		}

	}
}
