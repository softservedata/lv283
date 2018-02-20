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

        //[Test, TestCaseSource(nameof(SearchProduct))]
        public void VerifySearchByCurrency(Product product, string currencyName)
        {
            //HomeActions homeActions = Application.Get().LoadHomeActions();
            //SuccesSearchActions searchActions = homeActions.SuccesSearchProduct(product.Name);
            //
            // Precondition
            SuccesSearchActions searchActions = Application.Get()
                                                    .LoadHomeActions()
                                                    .SuccesSearchProduct(product.Name);
            // Steps
            searchActions = searchActions.ChooseCurrencyByPartialName(currencyName);
            // Verify
            Assert.AreEqual(product.GetPrice(currencyName), searchActions.GetPriceByProductName(product.Name), 0.01);
            // Return to previous state
            //searchActions.GotoHomeActions();
            //
            Thread.Sleep(2000);
        }

        private static readonly object[] SearchUsers =
        {
            new object[] { UserRepository.Get().Registered() }
        };

        [Test, TestCaseSource(nameof(SearchUsers))]
        public void VerifySuccessLogin(IUser validUser)
        {
            // Precondition
            // Steps
            MyAccountActions myAccountActions = Application.Get()
                                                    .LoadHomeActions()
                                                    .GotoLoginAccountActions()
                                                    .SuccessfulLogin(validUser);
            // Verify
            Assert.AreEqual("Logout", myAccountActions.MyAccountPageOperation.GetLogoutText());
            Thread.Sleep(2000);
            //
            // Return to previous state
            // TODO move to After Method
            myAccountActions.GotoLogoutAccountActions();
            //
            Thread.Sleep(2000);
        }
    }
}
