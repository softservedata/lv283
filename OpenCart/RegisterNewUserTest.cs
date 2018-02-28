using NUnit.Framework;
using OpenCart.Pages;
using OpenCart.Data.Users;

namespace OpenCart
{
    public class RegisterNewUserTest : TestRunner
    {
        private static readonly object[] UserData =
        {
            new object[] { UserRepository.Get().NewUser(), UserRepository.Get().AdminUser() },
        };

        [Test, TestCaseSource(nameof(UserData))]
        public void VerifyRegisterNewUser(IUser newUser, IUser admin)
        {
            log.Info("Started VerifyRegisterNewUser() with email = " + newUser.GetEmail());

            Assert.IsTrue(
                Application.Get().LoadHomeActions()
                .GotoRegisterAccountActions()
                .SuccessfulRegister(newUser)
                .GetLogout()
                .IsLoginDisplayed()
                );

            log.Info("Finished VerifyRegisterNewUser() with email = " + newUser.GetEmail());

            log.Info("Started deleting user with email = " + newUser.GetEmail());

            Assert.IsTrue(
                Application.Get().LoadAdminActions().GetLoginPage(admin)
                .GetCustomers()
                .GetDeletedCustomer(newUser)
                .IsCloseDisplayed()
                );

            isTestSuccess = true;
            log.Info("Finished deleting user with email = " + newUser.GetEmail());
        }
    }
}
