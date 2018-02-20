using OpenCart.Pages.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart.Actions.User
{
    public class ChosenProductActions
    {
        public ChosenProductPage ChosenProductOperation;

        public ChosenProductActions()
        {
            ChosenProductOperation = new ChosenProductPage();
        }
        public void GotoReviewTab()
        {
            ChosenProductOperation.ClickProductTab("Review");
        }

        public ChosenProductPage WriteReview(string customerName, string review, int rating)
        {
            GotoReviewTab();
            ChosenProductOperation.ClearNameFieldText();
            ChosenProductOperation.ClickNameFieldText();
            ChosenProductOperation.SetNameField(customerName);
            ChosenProductOperation.ClearReviewFieldText();
            ChosenProductOperation.ClearReviewFieldText();
            ChosenProductOperation.SetReviewField(review);
            ChosenProductOperation.ClickRatingFieldText(rating);
            ChosenProductOperation.ClickContinueButton();
            return new ChosenProductPage();
        }

        public ChosenProductPage WriteReviewAsRegisteredUser(string review, int rating)
        {
            GotoReviewTab();
            ChosenProductOperation.ClearReviewFieldText();
            ChosenProductOperation.ClearReviewFieldText();
            ChosenProductOperation.SetReviewField(review);
            ChosenProductOperation.ClickRatingFieldText(rating);
            ChosenProductOperation.ClickContinueButton();
            return new ChosenProductPage();
        }
    }
}
