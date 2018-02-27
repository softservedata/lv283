using NUnit.Framework;
using OpenCart.Actions.User;
using OpenCart.Data.Products;
using OpenCart.Data.Users;
using OpenCart.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart.Tests.AddingToWish
{
    [TestFixture]
    public class VerifyWishListFeature : TestRunner
    {
        private static readonly object[] SearchedProducts =
        {
            new object[] { ProductRepository.MacBook() },
            new object[] { ProductRepository.IPhone() }
        };

        [Test, TestCaseSource(nameof(SearchedProducts))]
        public void VerifySuccessAddingToWishList(Product product)
        {
            IUser validUser = UserRepository.Get().Registered();
            WishListActions wishListActions = Application.Get()
                                                    .LoadHomeActions()
                                                    .GotoLoginAccountActions()
                                                    .SuccessfulLogin(validUser)
                                                    .GotoHomeActions()
                                                    .ClickAddToWishByProductName(product.Name)
                                                    .GoToWishListPage();
            wishListActions.VerifyProductExistence(product.Name);
        }

        [Test, TestCaseSource(nameof(SearchedProducts))]
        public void VerifySuccessRemovingFromWishList(Product product)
        {
            IUser validUser = UserRepository.Get().Registered();
            WishListActions wishListActions = Application.Get()
                                                   .LoadHomeActions()
                                                   .GotoLoginAccountActions()
                                                   .SuccessfulLogin(validUser)
                                                   .GotoHomeActions()
                                                   .GoToWishListPage()
                                                   .ClickRemoveFromWish(product.Name);
            Assert.Throws<Exception>(() => wishListActions.VerifyProductExistence(product.Name));
        }
    }
}
