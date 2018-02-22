using OpenCart.Pages.User;

namespace OpenCart.Actions.User
{
	public class ColumnRightActions : AHeadActions
	{
		public RightPage RightPageOperation { get; private set; }

		public ColumnRightActions() : base()
		{
			RightPageOperation = new RightPage();
		}

		public MyAccountActions GotoMyAccountActions()
		{
			RightPageOperation.ClickMyAccountLink();
			return new MyAccountActions();
		}

		public EditAccountActions GotoEditAccountActions()
		{
			RightPageOperation.ClickEditAccountLink();
			return new EditAccountActions();
		}

		public EditPasswordActions GotoEditPasswordActions()
		{
			RightPageOperation.ClickEditPasswordLink();
			return new EditPasswordActions();
		}
	}
}
