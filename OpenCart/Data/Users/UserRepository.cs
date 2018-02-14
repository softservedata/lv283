using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart.Data.Users
{
    // 8. Use Repository
    // a) Use Static Class
    // b) All Static Methods
    // c) Use Pattern Singleton
    // 9. Use Singleton
    public class UserRepository
    {
        private volatile static UserRepository instance;
        private static object lockingObject = new object();

        private UserRepository()
        {
        }

        public static UserRepository Get()
        {
            if (instance == null)
            {
                lock (lockingObject)
                {
                    if (instance == null)
                    {
                        instance = new UserRepository();
                    }
                }
            }
            return instance;
        }

        public IUser Admin()
        {
            return User.Get()
                .SetFirstname("firstname8Admin")
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
                .SetAddressAdd("addressAdd")
                .Build();
        }

        public IUser DBUser()
        {
            // Read User From DB
            // Create Class for Read
            return User.Get()
                .SetFirstname("firstname9")
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
                .SetAddressAdd("addressAdd")
                .Build();
        }

        public List<IUser> ExcelUsers()
        {
            List<IUser> result = new List<IUser>();
            // Read User From Excel File
            // Create Class for Read
            result.Add(
                User.Get()
                .SetFirstname("firstname9")
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
                .SetAddressAdd("addressAdd")
                .Build()
            );
            return result;
        }
    }
}
