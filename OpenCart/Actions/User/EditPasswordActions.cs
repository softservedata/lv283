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

		public EditPasswordActions()
		{
			EditPasswordPageOperation = new EditPasswordPage();
		}



	}
}
