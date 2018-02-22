using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCart.Data.AccountsInfo;
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

		public EditAccountActions UnsuccessfulChangeAccount(IAccountInfo invalidAccountInfo)
		{
			EditAccountPageOperation.ChangeAccountData(invalidAccountInfo);
			return new EditAccountActions();
		}

		public EditAccountActions SuccessfulChangeAccount(IAccountInfo validAccountInfo)
		{
			EditAccountPageOperation.ChangeAccountData(validAccountInfo);
			return new EditAccountActions();
		}
	}
}
