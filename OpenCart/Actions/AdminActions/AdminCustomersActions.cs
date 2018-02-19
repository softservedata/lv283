using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCart.Pages.AdminPanel;
using OpenCart.Data.Users;

namespace OpenCart.Actions.AdminActions
{
    public class AdminCustomersActions
    {
        public AdminCustomersPage AdminCustomersOperation { get; private set; }

        public AdminCustomersActions()
        {
            AdminCustomersOperation = new AdminCustomersPage();
        }

        public AdminCustomersActions GetUnlockCustomer(IUser user)
        {
            AdminCustomersOperation.GetUnlockCustomer(user);
            return new AdminCustomersActions();
        }

        public AdminCustomersActions GetDeletedCustomer(IUser user)
        {
            AdminCustomersOperation.GetDeletedCustomer(user);
            return new AdminCustomersActions();
        }

        public AdminCustomersActions AcceptPopUp()
        {
            AdminCustomersOperation.GetAcceptPopUp();
            return new AdminCustomersActions();
        }

        public bool IsCloseDisplayed()
        {
            return AdminCustomersOperation.IsCloseDisplayed();
        }
    }
}
