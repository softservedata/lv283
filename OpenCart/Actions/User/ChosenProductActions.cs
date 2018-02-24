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

        //TODO
        //public void GotoChosenTab(string tabName)
        //{
        //    ChosenProductOperation.ClickProductTab();
        //}

        public ChosenProductActions WriteReview(string customerName, string review, int rating)
        {
            ChosenProductOperation.ClickReviewTab();
            ChosenProductOperation.ClearNameFieldText();
            ChosenProductOperation.ClickNameFieldText();
            ChosenProductOperation.SetNameField(customerName);
            ChosenProductOperation.ClearReviewFieldText();
            ChosenProductOperation.SetReviewField(review);
            ChosenProductOperation.ClickRatingFieldText(rating);
            ChosenProductOperation.ClickContinueButton();
            return new ChosenProductActions();
        }

        public ChosenProductActions WriteReviewAsRegisteredUser(string review, int rating)
        {
            ChosenProductOperation.ClickReviewTab();
            ChosenProductOperation.ClearReviewFieldText();
            ChosenProductOperation.ClearReviewFieldText();
            ChosenProductOperation.SetReviewField(review);
            ChosenProductOperation.ClickRatingFieldText(rating);
            ChosenProductOperation.ClickContinueButton();
            return new ChosenProductActions();
        }
    }
}
