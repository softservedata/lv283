using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenCart.Actions.User;
using OpenCart.Pages;
using OpenCart.Data.Commons;
using OpenCart.Data.Products;
using OpenCart.Pages.User;
using OpenCart.Pages.AdminPanel;
using OpenCart.Data.Users;

namespace OpenCart
{
    [TestFixture]
    public class SmokeLoginTest : TestRunner
    {
        private static readonly object[] SearchProduct =
        {
            new object[] { ProductRepository.macBook(), CurrencyRepository.Euro() },
            new object[] { ProductRepository.macBook(), CurrencyRepository.PoundSterling() },
            new object[] { ProductRepository.macBook(), CurrencyRepository.USDollar() }
        };

        [Test, TestCaseSource(nameof(SearchProduct))]
        public void VerifySearchByCurrency(Product product, string currencyName)
        {
            HomeActions homeActions = Application.Get().LoadHomeActions();
            SuccesSearchActions searchActions = homeActions.SuccesSearchProduct(product.Name);
            searchActions = searchActions.ChooseCurrencyByPartialName(currencyName);
            Assert.AreEqual(product.GetPrice(currencyName), searchActions.GetPriceByProductName(product.Name), 0.01);
            //
            Thread.Sleep(2000);
        }



        private static readonly object[] UserData =
        {
            //new object[] { UserRepository.Get().NewUser() },
            new object[] { UserRepository.Get().InvalidUser(), UserRepository.Get().AdminUser() },
            //new object[] { UserRepository.Get().AdminUser() }
        };

        [Test, TestCaseSource(nameof(UserData))]
        public void VerifyBlockUserByIncorrectPassword(IUser user, IUser admin)
        {
            Assert.IsTrue(Application.Get().LoadLoginPage().IsUserBlocked(user.GetEmail(), user.GetPassword()));

            Assert.IsTrue(Application.Get().LoadAdminPage().GetLoginToAdminPanel(admin.GetEmail(), admin.GetPassword())
                .GetCustomers().GetUnlockCustomer(user.GetEmail()));

            //Application.Get().LoadAdminPage().GetLoginToAdminPanel(admin.GetEmail(), admin.GetPassword())
            //    .GetCustomers().GetDeletedCustomer(user.GetEmail()).GetAcceptPopUp();

            Thread.Sleep(1000);
        }
    }
}
