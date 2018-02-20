using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCart.Pages.User;

namespace OpenCart.Actions.User
{
    public abstract class HeadActions
    {
        public HeadPage HeadPageOperation { get; private set; }

        public HeadActions()
        {
            HeadPageOperation = new HeadPage();
        }

        public HomeActions GotoHomeActions()
        {
            HeadPageOperation.GotoHome();
            return new HomeActions();
        }

        public SuccesSearchActions SuccesSearchProduct(string partialProductName)
        {
            HeadPageOperation.SuccesSearchProduct(partialProductName);
            return new SuccesSearchActions();
        }

        public RegisterAccountActions GotoRegisterAccountActions()
        {
            HeadPageOperation.GotoRegister();
            return new RegisterAccountActions();
        }

        public LoginAccountActions GotoLoginAccountActions()
        {
            HeadPageOperation.GotoLogin();
            return new LoginAccountActions();
        }

        public MyAccountActions GotoMyAccountActions()
        {
            HeadPageOperation.GotoMyAccount();
            return new MyAccountActions();
        }

        public LogoutActions GotoLogoutAccountActions()
        {
            HeadPageOperation.GotoLogout();
            return new LogoutActions();
        }

    }
}
