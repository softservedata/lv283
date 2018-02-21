using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCart.Pages.User;

namespace OpenCart.Actions.User
{
    public class RightActions : HeadActions
    {
        public RightPage RightPageOperation { get; private set; }

        public RightActions() : base()
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

    }
}
