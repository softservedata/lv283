using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCart.Data.Users;
using OpenCart.Pages.User;

namespace OpenCart.Actions.User
{
    class RegisterAccountActions
    {
        public RegisterAccountPage RegisterAccountPageOperation { get; private set; }

        public RegisterAccountActions()
        {
            RegisterAccountPageOperation = new RegisterAccountPage();
        }

        public RegisterAccountActions UnsuccessfulRegister(IUser invalidUser)
        {
            RegisterAccountPageOperation.RegisterUser(invalidUser);
            return new RegisterAccountActions();
        }

        public MyAccountActions SuccessfulRegister(IUser validUser)
        {
            RegisterAccountPageOperation.RegisterUser(validUser);
            return new MyAccountActions();
        }

    }
}
