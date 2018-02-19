using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCart.Pages.AdminPanel;
using OpenCart.Data.Users;

namespace OpenCart.Actions.AdminActions
{
    public class AdminPanelActions
    {
        public AdminPanelPage AdminPanelOperation { get; private set; }

        public AdminPanelActions()
        {
            AdminPanelOperation = new AdminPanelPage();
        }

        public AdminCustomersActions GetCustomers()
        {
            AdminPanelOperation.GetCustomers();
            return new AdminCustomersActions();
        }
    }
}
