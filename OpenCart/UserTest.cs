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
            //new object[] { "EUR", "MacBook", "560.94" },
            //new object[] { "GBP", "MacBook", "487.62" },
            //new object[] { "USD", "MacBook", "602.00" }
            //
            // 7. Parameterize Test
            //new object[]
            //{
            //    User.Get()
            //        .SetFirstname("firstname7")
            //        .SetLastname("lastname")
            //        .SetEmail("email")
            //        .SetPhone("phone")
            //        .SetAddressMain("addressMain")
            //        .SetCity("city")
            //        .SetPostcode("postcode")
            //        .SetCoutry("coutry")
            //        .SetRegionState("regionState")
            //        .SetPassword("password")
            //        .SetSubscribe(true)
            //        .SetFax("fax")
            //        .SetCompany("company")
            //        .SetAddressAdd("addressAdd")
            //        .Build()
            //}
            //
            // 8. Use Repository
            // 9. Use Singleton
            new object[] { UserRepository.Get().Admin() }
        };

        //[Test, TestCaseSource(nameof(UsersData))]
        //[Test]
        // 7. Parameterize Test
        [Test, TestCaseSource(nameof(UsersData))]
        public void CheckAddUser(IUser user)
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
            //User user = new User()
            //    .SetFirstname("firstname3")
            //    .SetLastname("lastname")
            //    .SetEmail("email")
            //    .SetPhone("phone")
            //    .SetAddressMain("addressMain")
            //    .SetCity("city")
            //    .SetPostcode("postcode")
            //    .SetCoutry("coutry")
            //    .SetRegionState("regionState")
            //    .SetPassword("password")
            //    .SetSubscribe(true)
            //    .SetFax("fax")
            //    .SetCompany("company")
            //    .SetAddressAdd("addressAdd");
            //Console.WriteLine("user.firstname = " + user.GetFirstname());
            //
            // 4. Static Factory
            //User user = User.Get()
            //    .SetFirstname("firstname4")
            //    .SetLastname("lastname")
            //    .SetEmail("email")
            //    .SetPhone("phone")
            //    .SetAddressMain("addressMain")
            //    .SetCity("city")
            //    .SetPostcode("postcode")
            //    .SetCoutry("coutry")
            //    .SetRegionState("regionState")
            //    .SetPassword("password")
            //    .SetSubscribe(true)
            //    .SetFax("fax")
            //    .SetCompany("company")
            //    .SetAddressAdd("addressAdd");
            //Console.WriteLine("user.firstname = " + user.GetFirstname());
            //
            // 5. Add Builder
            //User user = User.Get()
            //    .SetFirstname("firstname5")
            //    .SetLastname("lastname")
            //    .SetEmail("email")
            //    .SetPhone("phone")
            //    .SetAddressMain("addressMain")
            //    .SetCity("city")
            //    .SetPostcode("postcode")
            //    .SetCoutry("coutry")
            //    .SetRegionState("regionState")
            //    .SetPassword("password")
            //    .SetSubscribe(true)
            //    .SetFax("fax")
            //    .SetCompany("company")
            //    .SetAddressAdd("addressAdd")
            //    .Build();
            //Console.WriteLine("user.firstname = " + user.SetFirstname("hahaha"));
            //Console.WriteLine("user.firstname = " + user.GetFirstname());
            //
            // 6. Add Dependency Inversion
            //IUser user = User.Get()
            //    .SetFirstname("firstname6")
            //    .SetLastname("lastname")
            //    .SetEmail("email")
            //    .SetPhone("phone")
            //    .SetAddressMain("addressMain")
            //    .SetCity("city")
            //    .SetPostcode("postcode")
            //    .SetCoutry("coutry")
            //    .SetRegionState("regionState")
            //    .SetPassword("password")
            //    .SetSubscribe(true)
            //    .SetFax("fax")
            //    .SetCompany("company")
            //    .SetAddressAdd("addressAdd")
            //    .Build();
            //Console.WriteLine("user.firstname = " + user.SetFirstname("hahaha")); // Compile ERROR
            //((User)user).SetFirstname("hahaha");
            //Console.WriteLine("user.firstname = " + user.GetFirstname());
            //
            // 7. Parameterize Test
            Console.WriteLine("user.firstname = " + user.GetFirstname());
        }
    }
}
