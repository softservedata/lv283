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
        private static readonly object[] UsersData =
        {
            //new object[] { "EUR", "MacBook", "560.94" },
            //new object[] { "GBP", "MacBook", "487.62" },
            new object[] { "USD", "MacBook", "602.00" }
        };

        //[Test, TestCaseSource(nameof(UsersData))]
        [Test]
        public void CheckAddUser()
        {
            // 1. Use Full Constructor
            //User user = new User("firstname1", "lastname", "email",
            //    "phone", "addressMain", "city",
            //    "postcode", "coutry", "regionState",
            //    "password", true);
            //Console.WriteLine("user.firstname = " + user.GetFirstname());
            //
            // 2. Use Setters. Undestanding Parameters
            //User user = new User();
            //user.SetFirstname("firstname2");
            //user.SetLastname("lastname");
            //user.SetEmail("email");
            //user.SetPhone("phone");
            //user.SetAddressMain("addressMain");
            //user.SetCity("city");
            //user.SetPostcode("postcode");
            //user.SetCoutry("coutry");
            //user.SetRegionState("regionState");
            //user.SetPassword("password");
            //user.SetSubscribe(true);
            //user.SetFax("fax");
            //user.SetCompany("company");
            //user.SetAddressAdd("addressAdd");
            //Console.WriteLine("user.firstname = " + user.GetFirstname());
            //
            // 3. Add Fluent Interface
            User user = new User()
                .SetFirstname("firstname3")
                .SetLastname("lastname")
                .SetEmail("email")
                .SetPhone("phone")
                .SetAddressMain("addressMain")
                .SetCity("city")
                .SetPostcode("postcode")
                .SetCoutry("coutry")
                .SetRegionState("regionState")
                .SetPassword("password")
                .SetSubscribe(true)
                .SetFax("fax")
                .SetCompany("company")
                .SetAddressAdd("addressAdd");
            Console.WriteLine("user.firstname = " + user.GetFirstname());
            //
            // 4.
        }
    }
}
