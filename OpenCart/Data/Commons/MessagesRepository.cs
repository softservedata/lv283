using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart.Data.Commons
{
    public sealed class MessagesRepository
    {
        private MessagesRepository() { }

        public static string DangerMessage()
        {
            return "Warning: Your account has exceeded allowed number of login attempts. Please try again in 1 hour.";
        }
    }
}
