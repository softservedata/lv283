using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenCart.Data.Users;

namespace OpenCart
{
    [TestFixture]
    public class UserTest
    {
        // DataProvider
        private static readonly object[] UsersData =
        {
           new object[] { UserRepository.Get().Admin() }
        };

        //Parameterize Test
        [Test, TestCaseSource(nameof(UsersData))]
        public void CheckAddUser(IUser user)
        {
           
            Console.WriteLine("user.firstname = " + user.GetFirstname());
        }
    }
}
