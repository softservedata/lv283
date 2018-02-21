using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart.Pages.User
{
	public class MyAccountPage : AColumnRightUserComponent
	{
		public MyAccountPage() : base() { }

		public EditAccountPage GotoEditAccountPageFromRightColumn()
		{
			ClickEditAccount();
			return new EditAccountPage();
		}

		public EditPasswordPage GotoEditPasswordPageFromRightColumn()
		{
			ClickPassword();
			return new EditPasswordPage();
		}
	}
}
