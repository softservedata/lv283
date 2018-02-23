using NUnit.Framework;
using OpenCart.Actions.User;
using OpenCart.Data.Products;
using OpenCart.Data.Reviews;
using OpenCart.Pages;
using System;


namespace OpenCart
{
    [TestFixture]
    public class ReviewTest :TestRunner
    {
        private static readonly object[] SearchProduct =
        {
            new object[] { ReviewRepository.Get().NotExistingUserReview(), ProductRepository.macBook() }
        };

        [Test, TestCaseSource(nameof(SearchProduct))]
        public void VerifyReviewCreationForNotExistingUser(Review review, Product product)
        {

            ChosenProductActions searchActions = Application.Get()
                                                    .LoadHomeActions()
                                                    .SuccesSearchProduct(product.Name)
                                                    .ChooseProductByPartialName(product.Name)
                                                    .WriteReview(review.GetNameField(), review.GetReviewField(), review.GetRatingField());

			StringAssert.AreEqualIgnoringCase(AlertsText.SUCCESSREVIEW, searchActions.ChosenProductOperation.GetMessage());
		}
	}
}
