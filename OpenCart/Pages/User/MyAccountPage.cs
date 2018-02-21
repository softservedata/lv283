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
			ClickEditAccountLink();
			return new EditAccountPage();
		}

		public EditPasswordPage GotoEditPasswordPageFromRightColumn()
		{
			ClickPasswordLink();
			return new EditPasswordPage();
		}
	}
}
