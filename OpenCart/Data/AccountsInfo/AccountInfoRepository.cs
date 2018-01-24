using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
				.SetEmail("lion@gmail.com")
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
				.SetEmail("lion@gmail.com")
				.SetPhone("20172017201720172017201720172017s")
				.SetFax("fax")
				.Build();
		}


		public List<IAccountInfo> ExcelUsers()
		{
			List<IAccountInfo> result = new List<IAccountInfo>();
			result.Add(
				AccountInfo.Get()
				.SetFirstname("firstname9")
				.SetLastname("lastname")
				.SetEmail("email")
				.SetPhone("phone")
				.SetFax("fax")
				.Build()
			);
			return result;
		}

	}
	}
