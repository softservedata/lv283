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
		public IPassword IncorrectPasswordLessThanFour()
		{
			return Password.Get()
				.SetPasswordField("qwe")
				.SetConfirmField("qwe")
				.Build();
		}

		public IPassword IncorrectPasswordLessThanTwentyOne()
		{
			return Password.Get()
				.SetPasswordField("q20172017201720172017")
				.SetConfirmField("q20172017201720172017")
				.Build();
		}

		public IPassword IncorrectConfirm()
		{
			return Password.Get()
				.SetPasswordField("qwety")
				.SetConfirmField("qwerty1111111")
				.Build();
		}

		public IPassword PasswordFour()
		{
			return Password.Get()
				.SetPasswordField("qwer")
				.SetConfirmField("qwer")
				.Build();
		}

		public IPassword PasswordTwenty()
		{
			return Password.Get()
				.SetPasswordField("20172017201720172017")
				.SetConfirmField("20172017201720172017")
				.Build();
		}

		public IPassword PasswordSix()
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
