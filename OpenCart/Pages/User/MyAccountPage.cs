
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
			ClickEditPasswordLink();
			return new EditPasswordPage();
		}
	}
}
