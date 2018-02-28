using NUnit.Framework;
using OpenCart.Actions.User;
using OpenCart.Data.Products;
using OpenCart.Data.Reviews;
using OpenCart.Data.Users;
using OpenCart.Pages;
using System;


namespace OpenCart
{
    [TestFixture]
    public class ReviewTest :TestRunner
    {
        private static readonly object[] SearchProduct =
        {
            new object[] { ReviewRepository.Get().NotExistingUserReview(), ProductRepository.MacBook() }
        };

       // [Test, TestCaseSource("SearchProduct")]
        public void VerifyReviewCreationForNotExistingUser(Review review, Product product)
        {

            ChosenProductActions searchActions = Application.Get()
                                                    .LoadHomeActions()
                                                    .SuccesSearchProduct(product.Name)
                                                    .ChooseProductByPartialName(product.Name)
                                                    .WriteReview(review.GetNameField(), review.GetReviewField(), review.GetRatingField());

			StringAssert.AreEqualIgnoringCase(AlertsText.SUCCESSREVIEW, searchActions.ChosenProductOperation.GetMessage());
		}


        private static readonly object[] ProductReviewForRegisteredUser =
         {
            new object[] { UserRepository.Get().ReviewUser(), ProductRepository.MacBook() }
        };


        //[Test, TestCaseSource("ProductReviewForRegisteredUser")]
        public void VerifyUserNameForReviewCreate(IUser user, Product product)
        {
            string result = Application.Get()
                                        .LoadHomeActions()
                                        .GotoLoginAccountActions()
                                        .SuccessfulLogin(user)
                                        .GotoHomeActions()
                                        .SuccesSearchProduct(product.Name)
                                        .ChooseProductByPartialName(product.Name)
                                        .ChosenProductOperation
                                        .GetNameFieldFromReview();
            Console.WriteLine(result);
            string expected = user.GetFirstname() + " " + user.GetLastname();

            Assert.IsFalse(expected.Equals( result));
        }

    }
}
