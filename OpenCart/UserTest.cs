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
		//DataProvider
		private static readonly object[] UsersData =
		{
            //Use Repository
            //Use Singleton
            new object[] { UserRepository.Get().AdminUser() }
		};

		//Parameterize Test
		[Test, TestCaseSource(nameof(UsersData))]
		public void CheckAddUser(IUser user)
		{
			//Parameterize Test
			Console.WriteLine("user.firstname = " + user.GetFirstname());
		}
	}
}
