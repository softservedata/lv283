//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
///////////////////////TODO/////////////////////
//namespace OpenCart.Data.EditAddress
//{
//    public class EditAddressRepository
//    {
//        private volatile static EditAddressRepository instance;
//        private static object lockingObject = new object();

//        private EditAddressRepository()
//        {
//        }

//        public static EditAddressRepository Get()
//        {
//            if (instance == null)
//            {
//                lock (lockingObject)
//                {
//                    if (instance == null)
//                    {
//                        instance = new EditAddressRepository();
//                    }
//                }
//            }
//            return instance;
//        }

//        public IEditAddress EditAddressUserData()
//        {
//            return EditAddress.Get()
//                .SetFirstname("David")
//                .SetLastname("O`Conner")
//                .SetAddressMain("Independence Square")
//                .SetCity("Dublin")
//                .SetPostcode("33167")
//                .SetCoutry("Ireland")
//                .SetRegionState("Dublin")
//                .Build();
//        }

//        public IEditAddress AddAddressUserData()
//        {
//            return EditAddress.Get()
//                .SetFirstname("Marc")
//                .SetLastname("Rockfeler")
//                .SetCompany("Global Development Inc.")
//                .SetAddress("Green Street")
//                .SetAdditionalAddress("Lindon Johnson Square")
//                .SetCity("London")
//                .SetPostcode("88015")
//                .SetCoutry("United Kingdom")
//                .SetRegionState("Greater London")
//                .Build();
//        }
//    }
//}
