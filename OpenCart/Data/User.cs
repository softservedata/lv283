using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart.Data
{
    public interface IEmail
    {
        IPassword SetEmail(string email);
    }
     
    public interface IPassword
    {
        IUserBuilder SetPasw(string pasw);
    }

    public interface IUserBuilder
    {
        IUser Build();
    }
    public interface IUser
    {
        string GetEmail();
        string GetPassword();
    }
    

    public class User: IEmail, IPassword, IUserBuilder, IUser
    {
        private string email;
        private string pasw;

        private User()
        {

        }

        public static IEmail Get()
        {
            return new User();
        }

        public IPassword SetEmail(string email)
        {
            this.email = email;
            return this;
        }

        public IUserBuilder SetPasw(string pasw)
        {
            this.pasw = pasw;
            return this;
        }

        public IUser Build()
        {
            return this;
        }

        public string GetEmail()
        {
            return email;
        }

        public string GetPassword()
        {
            return pasw;
        }
    }
}
