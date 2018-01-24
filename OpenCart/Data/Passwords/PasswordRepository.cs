using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart.Data.Passwords
{
	public class PasswordRepository
	{
		private volatile static PasswordRepository instance;
		private static object lockingObject = new object();

		private PasswordRepository()
		{
		}

		public static PasswordRepository Get()
		{
			if (instance == null)
			{
				lock (lockingObject)
				{
					if (instance == null)
					{
						instance = new PasswordRepository();
					}
				}
			}
			return instance;
		}

		//Data for Admin user from admin panel
		//Currently incorrect
		public IPassword AdminPassword()
		{
			return Password.Get()
				.SetPasswordField("qwerty")
				.SetConfirmField("qwerty")
				.Build();
		}

		public List<IPassword> ExcelPasswords()
		{
			List<IPassword> result = new List<IPassword>();
			result.Add(
				Password.Get()
				.SetPasswordField("qwerty")
				.SetConfirmField("qwerty")
				.Build()
			);
			return result;
		}

	}
}
