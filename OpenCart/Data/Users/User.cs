﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart.Data.Users
{
	public interface IFirstname
	{
		ILastname SetFirstname(string firstname);
	}

	public interface ILastname
	{
		IEmail SetLastname(string lastname);
	}

	public interface IEmail
	{
		IPhone SetEmail(string email);
	}

	public interface IPhone
	{
		IAddressMain SetPhone(string phone);
	}

	public interface IAddressMain
	{
		ICity SetAddressMain(string addressMain);
	}

	public interface ICity
	{
		IPostcode SetCity(string city);
	}

	public interface IPostcode
	{
		ICoutry SetPostcode(string postcode);
	}

	public interface ICoutry
	{
		IRegionState SetCoutry(string coutry);
	}

	public interface IRegionState
	{
		IPassword SetRegionState(string regionState);
	}

	public interface IPassword
	{
		ISubscribe SetPassword(string password);
	}

	public interface ISubscribe
	{
		IFax SetSubscribe(bool subscribe);
	}

	public interface IFax : IUserBuilder
	{
		ICompany SetFax(string fax);
	}

	public interface ICompany : IUserBuilder
	{
		IAddressAdd SetCompany(string company);
	}

	public interface IAddressAdd : IUserBuilder
	{
		IUserBuilder SetAddressAdd(string addressAdd);
	}

	public interface IUserBuilder
	{
		IUser Build();
	}

	// Add Dependency Inversion
	public interface IUser
	{
		string GetFirstname();
		string GetLastname();
		string GetEmail();
		string GetPhone();
		string GetAddressMain();
		string GetCity();
		string GetPostcode();
		string GetCoutry();
		string GetRegionState();
		string GetPassword();
		bool GetSubscribe();
		string GetFax();
		string GetCompany();
		string GetAddressAdd();
	}

	public class User : IFirstname, ILastname, IEmail,
		IPhone, IAddressMain, ICity, IPostcode, ICoutry,
		IRegionState, IPassword, ISubscribe,
		IFax, ICompany, IAddressAdd, IUserBuilder, IUser
	{
		// Required
		private string firstname;
		private string lastname;
		private string email;
		private string phone;
		private string addressMain;
		private string city;
		private string postcode;
		private string coutry;
		private string regionState;
		private string password;
		private bool subscribe;
		// Advanced
		private string fax;
		private string company;
		private string addressAdd;

		private User()
		{ }

		public static IFirstname Get()
		{
			return new User();
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

		public IAddressMain SetPhone(string phone)
		{
			this.phone = phone;
			return this;
		}

		public ICity SetAddressMain(string addressMain)
		{
			this.addressMain = addressMain;
			return this;
		}

		public IPostcode SetCity(string city)
		{
			this.city = city;
			return this;
		}

		public ICoutry SetPostcode(string postcode)
		{
			this.postcode = postcode;
			return this;
		}

		public IRegionState SetCoutry(string coutry)
		{
			this.coutry = coutry;
			return this;
		}

		public IPassword SetRegionState(string regionState)
		{
			this.regionState = regionState;
			return this;
		}

		public ISubscribe SetPassword(string password)
		{
			this.password = password;
			return this;
		}

		public IFax SetSubscribe(bool subscribe)
		{
			this.subscribe = subscribe;
			return this;
		}

		public ICompany SetFax(string fax)
		{
			this.fax = fax;
			return this;
		}

		public IAddressAdd SetCompany(string company)
		{
			this.company = company;
			return this;
		}

		public IUserBuilder SetAddressAdd(string addressAdd)
		{
			this.addressAdd = addressAdd;
			return this;
		}

		//Add Dependency Inversion
		public IUser Build()
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

		public string GetAddressMain()
		{
			return addressMain;
		}

		public string GetCity()
		{
			return city;
		}

		public string GetPostcode()
		{
			return postcode;
		}

		public string GetCoutry()
		{
			return coutry;
		}

		public string GetRegionState()
		{
			return regionState;
		}

		public string GetPassword()
		{
			return password;
		}

		public bool GetSubscribe()
		{
			return subscribe;
		}

		public string GetFax()
		{
			return fax;
		}

		public string GetCompany()
		{
			return company;
		}

		public string GetAddressAdd()
		{
			return addressAdd;
		}
	}
}
