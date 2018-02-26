
namespace OpenCart.Data.Passwords
{
	public interface IPasswordField : IPasswordBuilder
	{
		IConfirmField SetPasswordField(string passwordField);
	}

	public interface IConfirmField : IPasswordBuilder
	{
		IPasswordBuilder SetConfirmField(string confirmField);
	}

	public interface IPasswordBuilder
	{
		IPassword Build();
	}

	// Add Dependency Inversion
	public interface IPassword
	{
		string GetPasswordField();
		string GetConfirmField();

	}

	public class Password : IPasswordField, IConfirmField, IPasswordBuilder,
		IPassword
	{
		// Required
		private string passwordField;
		private string confirmField;


		private Password()
		{ }

		public static IPasswordField Get()
		{
			return new Password();
		}

		// Add Builder

		public IConfirmField SetPasswordField(string passwordField)
		{
			this.passwordField = passwordField;
			return this;
		}

		public IPasswordBuilder SetConfirmField(string confirmField)
		{
			this.confirmField = confirmField;
			return this;
		}

		//Add Dependency Inversion
		public IPassword Build()
		{
			return this;
		}

		// Getters
		public string GetPasswordField()
		{
			return passwordField;
		}

		public string GetConfirmField()
		{
			return confirmField;
		}

	}
}
