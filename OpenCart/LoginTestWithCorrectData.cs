using NUnit.Framework;
using OpenCart.Pages;
using OpenCart.Data.Users;

namespace OpenCart
{
    [TestFixture]
    public class LoginTestWithCorrectData : TestRunner
    {
        private static readonly object[] UserData =
        {
            new object[] { UserRepository.Get().ValidUser() },
        };

        [Test, TestCaseSource(nameof(UserData))]
        public void VerifyLogin(IUser validUser)
        {
            log.Info("Started VerifyLogin() with email = " + validUser.GetEmail());
            Assert.IsTrue(
                Application.Get().LoadHomeActions()
                .GotoLoginAccountActions()
                .SuccessfulLogin(validUser)
                .GetLogout()
                .IsLoginDisplayed()
                );
            isTestSuccess = true;
            log.Info("Finished VerifyLogin() with email = " + validUser.GetEmail());
        }
    }
}
