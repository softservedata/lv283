
namespace OpenCart.Data.AccountsInfo
{
	public class AccountInfoRepository
	{
		private volatile static AccountInfoRepository instance;
		private static object lockingObject = new object();

		private AccountInfoRepository()
		{
		}

		public static AccountInfoRepository Get()
		{
			if (instance == null)
			{
				lock (lockingObject)
				{
					if (instance == null)
					{
						instance = new AccountInfoRepository();
					}
				}
			}
			return instance;
		}

		//Valid edit data
		public IAccountInfo ValidUser()
		{
			return AccountInfo.Get()
				.SetFirstname("Vova")
				.SetLastname("Lion")
				.SetEmail("hahaha@gmail.com")
				.SetPhone("+3865656565656")
				.SetFax("fax")
				.Build();
		}

		//Invalid edit data
		public IAccountInfo InvalidUser()
		{
			return AccountInfo.Get()
				.SetFirstname("20172017201720172017201720172017s")
				.SetLastname("20172017201720172017201720172017s")
				.SetEmail("lio11111111111111111111111111111111111111111111111111111111111111111n@gmail.com")
				.SetPhone("20172017201720172017201720172017s")
				.SetFax("fax")
				.Build();
		}


		public IAccountInfo User1()
		{
			return AccountInfo.Get()
				.SetFirstname("firstname9")
				.SetLastname("lastname")
				.SetEmail("l@gmail.com")
				.SetPhone("phone")
				.SetFax("fax")
				.Build();
		}
		public IAccountInfo User2()
		{
			return AccountInfo.Get()
				.SetFirstname("firstname9")
				.SetLastname("lastname")
				.SetEmail("lion@g.com")
				.SetPhone("phone")
				.SetFax("fax")
				.Build();
		}
		public IAccountInfo User3()
		{
			return AccountInfo.Get()
			.SetFirstname("firstname9")
			.SetLastname("lastname")
			.SetEmail("lion@gmail.c")
			.SetPhone("phone")
			.SetFax("fax")
			.Build();
		}
		public IAccountInfo User4()
		{
			return AccountInfo.Get()
			.SetFirstname("firstname9")
			.SetLastname("lastname")
			.SetEmail("l@g.com")
			.SetPhone("phone")
			.SetFax("fax")
			.Build();
		}
		public IAccountInfo User5()
		{
			return AccountInfo.Get()
			.SetFirstname("firstname9")
			.SetLastname("lastname")
			.SetEmail("l@gmail.c")
			.SetPhone("phone")
			.SetFax("fax")
			.Build();
		}
		public IAccountInfo User6()
		{
			return AccountInfo.Get()
			.SetFirstname("firstname9")
			.SetLastname("lastname")
			.SetEmail("l@g.c")
			.SetPhone("phone")
			.SetFax("fax")
			.Build();
		}
		public IAccountInfo User7()
		{
			return AccountInfo.Get()
			.SetFirstname("firstname9")
			.SetLastname("lastname")
			.SetEmail("lion@gmail.com")
			.SetPhone("phone")
			.SetFax("fax")
			.Build();
		}

	}
}
