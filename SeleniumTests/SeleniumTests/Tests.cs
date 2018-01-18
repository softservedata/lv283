using NUnit.Framework;

namespace SeleniumTests
{
    [TestFixture]
    public class Tests : TestRunner
    {  
        private static readonly object[] UserDataForLogin =
        {
            new object[] { "random@random.com", "123456"}
        };
        
        /// <summary>
        /// Test case #1
        /// 1. Open http://zewer.beget.tech
        /// 2. Choose "My Account" -> "Login"
        /// 3. Fill "E-Mail Address" and "Password" fields with the following data:
        /// "E-Mail Address" - random @random.com
        /// "Password" - 123456
        /// 4. Click "Login" Button.
        /// 5. Login operation should be done
        /// </summary>
        [Test, TestCaseSource(nameof(UserDataForLogin))]
        public void Login_TrueReturned(string email, string password)
        {
            LoginModule login = new LoginModule(driver);

            Assert.IsTrue(login.Login(email, password));
        }
            
        private static readonly object[] UserDataForIncorrectLogin =
        {
            new object[] { "random@random.com", "12321"}
        };

        /// <summary>
        /// Test case #2
        /// 1. Open http://zewer.beget.tech
        /// 2. Choose "My Account" -> "Login"
        /// 3. Fill "E-Mail Address" field with "random@random.com" data and "Password" with "12321" data.
        /// 4. Repeat in total 5 times.
        /// 5. Account should be blocked for 1 hour
        /// </summary>  
        [Test, TestCaseSource(nameof(UserDataForIncorrectLogin))]
        public void LoginWithIncorrectData_TrueReturned(string email, string password)
        {
            LoginModule login = new LoginModule(driver);

            Assert.IsTrue(login.LoginBlocked(email, password));
            Assert.IsTrue(login.Unblock(email));
        }        
        
        private static readonly object[] UserDataForRegister =
        {
            new object[] { "randomm@randomm.com", "123456" }            
        };

        /// <summary>
        /// Test case #3
        /// 1. Open http://zewer.beget.tech
        /// 2. Choose "My Account" -> "Register"
        /// 3. Fill all fields with the following data:
        /// "First Name" - qwerty
        /// "Last Name" - ytrewq
        /// "E-Mail" - randomm @randomm.com
        /// "Telephone" - 1234321
        /// "Fax" - 1234321
        /// "Company" - any
        /// "Address 1" - any
        /// "Address 2" - any
        /// "City" - any
        /// "Post Code" - 12345
        /// "Country" - United Kingdom
        /// "Region/State" - Aberdeen
        /// "Password" - 123456
        /// "Password Confirm" - 123456
        /// "Subscribe" - No
        /// Confirm that you have read Privacy Policy
        /// 4. Click "Continue" button.
        /// 5. New user should be created.
        /// </summary>
        [Test, TestCaseSource(nameof(UserDataForRegister))]
        public void Register_TrueReturned(string email, string password)
        {           
            RegisterModule login = new RegisterModule(driver);

            Assert.IsTrue(login.Register(email, password));
            Assert.IsTrue(login.DeleteUser(email));
        }
    }
}
