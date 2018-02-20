using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCart.Data.Users;
using OpenCart.Pages.User;

namespace OpenCart.Actions.User
{
    public class LoginAccountActions : RightActions
    {
        public LoginAccountPage LoginAccountPageOperation { get; private set; }

        public LoginAccountActions()
        {
            LoginAccountPageOperation = new LoginAccountPage();
        }

        public MyAccountActions UnsuccessfulLogin(IUser invalidUser)
        {
            LoginAccountPageOperation.LoginUser(invalidUser);
            return new MyAccountActions();
        }

        public MyAccountActions SuccessfulLogin(IUser validUser)
        {
            LoginAccountPageOperation.LoginUser(validUser);
            return new MyAccountActions();
        }

    }
}
