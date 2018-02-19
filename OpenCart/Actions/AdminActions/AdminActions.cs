using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCart.Pages.AdminPanel;
using OpenCart.Data.Users;
using OpenCart.Pages.User;

namespace OpenCart.Actions.AdminActions
{
    public class AdminActions
    {
        public AdminLoginPage AdminLoginPageOperation { get; private set; }

        public AdminActions()
        {
            AdminLoginPageOperation = new AdminLoginPage();
        }

        public AdminPanelActions GetLoginPage(IUser admin)
        {
            AdminLoginPageOperation.GetLoginToAdminPanel(admin);
            return new AdminPanelActions();
        }
    }
}
