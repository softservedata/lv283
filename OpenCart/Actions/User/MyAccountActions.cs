﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCart.Data.Users;
using OpenCart.Pages.User;

namespace OpenCart.Actions.User
{
    public class MyAccountActions : RightActions
    {
        public MyAccountPage MyAccountPageOperation { get; private set; }

        public MyAccountActions() : base()
        {
            MyAccountPageOperation = new MyAccountPage();
            MyAccountPageOperation.IsLoggedin = true;
        }

    }
}
