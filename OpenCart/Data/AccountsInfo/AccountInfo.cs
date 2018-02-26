
namespace OpenCart.Data.AccountsInfo
{
	public interface IFirstname : IAccountInfoBuilder
	{
		ILastname SetFirstname(string firstname);
	}

	public interface ILastname : IAccountInfoBuilder
	{
		IEmail SetLastname(string lastname);
	}

	public interface IEmail : IAccountInfoBuilder
	{
		IPhone SetEmail(string email);
	}

	public interface IPhone : IAccountInfoBuilder
	{
		IFax SetPhone(string phone);
	}

	public interface IFax : IAccountInfoBuilder
	{
		IAccountInfoBuilder SetFax(string fax);
	}

	public interface IAccountInfoBuilder
	{
		IAccountInfo Build();
	}

	// Add Dependency Inversion
	public interface IAccountInfo
	{
		string GetFirstname();
		string GetLastname();
		string GetEmail();
		string GetPhone();

		string GetFax();
	}

	public class AccountInfo : IFirstname, ILastname, IEmail,
							 IPhone, IFax, IAccountInfoBuilder, IAccountInfo
	{
		private string firstname;
		private string lastname;
		private string email;
		private string phone;

		// Advanced
		private string fax;


		private AccountInfo()
		{ }

		public static IFirstname Get()
		{
			return new AccountInfo();
		}

		// Add Builder
		public ILastname SetFirstname(string firstname)
		{
			this.firstname = firstname;
			return this;
		}

		public IEmail SetLastname(string lastname)
		{
			this.lastname = lastname;
			return this;
		}

		public IPhone SetEmail(string email)
		{
			this.email = email;
			return this;
		}

		public IFax SetPhone(string phone)
		{
			this.phone = phone;
			return this;
		}



		public IAccountInfoBuilder SetFax(string fax)
		{
			this.fax = fax;
			return this;
		}

		//Add Dependency Inversion
		public IAccountInfo Build()
		{
			return this;
		}

		// Getters
		public string GetFirstname()
		{
			return firstname;
		}

		public string GetLastname()
		{
			return lastname;
		}
		public string GetEmail()
		{
			return email;
		}

		public string GetPhone()
		{
			return phone;
		}

		public string GetFax()
		{
			return fax;
		}


	}
}
