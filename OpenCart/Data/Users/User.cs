using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart.Data.Users
{
    public class User
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

        // 1. Bad practics
        //public User(string firstname, string lastname, string email,
        //    string phone, string addressMain, string city,
        //    string postcode, string coutry, string regionState,
        //    string password, bool subscribe)
        //{
        //    this.firstname = firstname;
        //    this.lastname = lastname;
        //    this.email = email;
        //    this.phone = phone;
        //    this.addressMain = addressMain;
        //    this.city = city;
        //    this.postcode = postcode;
        //    this.coutry = coutry;
        //    this.regionState = regionState;
        //    this.password = password;
        //    this.subscribe = subscribe;
        //}
        //
        // 2. Add public Default Constructor and Setters/Getters
        public User()
        { }

        // Setters

        // 2.
        //public void SetFirstname(string firstname)
        // 3. Add Fluent Interface
        public User SetFirstname(string firstname)
        {
            this.firstname = firstname;
            return this;
        }

        public User SetLastname(string lastname)
        {
            this.lastname = lastname;
            return this;
        }

        public User SetEmail(string email)
        {
            this.email = email;
            return this;
        }

        public User SetPhone(string phone)
        {
            this.phone = phone;
            return this;
        }

        public User SetAddressMain(string addressMain)
        {
            this.addressMain = addressMain;
            return this;
        }

        public User SetCity(string city)
        {
            this.city = city;
            return this;
        }

        public User SetPostcode(string postcode)
        {
            this.postcode = postcode;
            return this;
        }

        public User SetCoutry(string coutry)
        {
            this.coutry = coutry;
            return this;
        }

        public User SetRegionState(string regionState)
        {
            this.regionState = regionState;
            return this;
        }

        public User SetPassword(string password)
        {
            this.password = password;
            return this;
        }

        public User SetSubscribe(bool subscribe)
        {
            this.subscribe = subscribe;
            return this;
        }

        public User SetFax(string fax)
        {
            this.fax = fax;
            return this;
        }

        public User SetCompany(string company)
        {
            this.company = company;
            return this;
        }

        public User SetAddressAdd(string addressAdd)
        {
            this.addressAdd = addressAdd;
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
