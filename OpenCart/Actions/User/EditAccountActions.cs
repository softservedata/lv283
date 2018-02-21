using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCart.Pages.User;

namespace OpenCart.Actions.User
{
	public class EditAccountActions : ColumnRightActions
	{
		public EditAccountPage EditAccountPageOperation { get; private set; }

		public EditAccountActions() : base()
		{
			EditAccountPageOperation = new EditAccountPage();
		}
	}
}
