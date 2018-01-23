using NUnit.Framework;
using SeleniumTests.Data.Users;

namespace SeleniumTests
{
    [TestFixture]
    public class Tests : TestRunner
    {  
        private static readonly object[] UserDataForLogin =
        {
            //new object[] { "random@random.com", "123456"}
            new object[] { UserRepository.Get().ValidUser() }
        };
        
        [Test, TestCaseSource(nameof(UserDataForLogin))]
        public void Login_TrueReturned(IUser user)
        {
            LoginModule login = new LoginModule(driver);

            Assert.IsTrue(login.Login(user));
        }
            
        private static readonly object[] UserDataForIncorrectLogin =
        {
            //new object[] { "random@random.com", "12321"}
            new object[] { UserRepository.Get().InvalidUser() }
        };

        [Test, TestCaseSource(nameof(UserDataForIncorrectLogin))]
        public void LoginWithIncorrectData_TrueReturned(IUser user)
        {
            LoginModule login = new LoginModule(driver);

            Assert.IsTrue(login.LoginBlocked(user));
            Assert.IsTrue(login.Unblock(user));
        }        
        
        private static readonly object[] UserDataForRegister =
        {
            //new object[] { "randomm@randomm.com", "123456" }    
            new object[] { UserRepository.Get().NewUser() }
        };

        [Test, TestCaseSource(nameof(UserDataForRegister))]
        public void Register_TrueReturned(IUser user)
        {           
            RegisterModule login = new RegisterModule(driver);

            Assert.IsTrue(login.Register(user));
            Assert.IsTrue(login.DeleteUser(user));
        }
    }
}
