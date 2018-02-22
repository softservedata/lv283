
using System;

namespace OpenCart.Data.Reviews
{
    public interface INameField 
    {
        IRatingField SetNameField(string nameField);
    }

    public interface IReviewField 
    {
        IRatingField SetReviewField(string reviewField);
    }
    public interface IRatingField : INameField
    {
        IReviewBuilder SetRatingField(int rating);
    }

    public interface IReviewBuilder
    {
        IReview Build();
    }

    // Add Dependency Inversion
    public interface IReview
    {
        string GetNameField();
        string GetReviewField();
        int GetRatingField();

    }


    public class Review : INameField, IRatingField, IReview, IReviewField, IReviewBuilder
	{
		// Required
		private string nameField;
        private string reviewField;
        private int rating;


        private Review()
        { }

        public static IReviewField Get()
        {
            return new Review();
        }

        // Add Builder

        public IRatingField SetNameField(string nameField)
        {
            this.nameField = nameField;
            return this;
        }

        public IRatingField SetReviewField(string reviewField)
        {
            this.reviewField = reviewField;
            return this;
        }

        public IReviewBuilder SetRatingField(int rating)
        {
            this.rating = rating;
            return this;
        }

        //Add Dependency Inversion
        public IReview Build()
        {
            return this;
        }

        // Getters
        public string GetNameField()
        {
            return nameField;
        }

        public string GetReviewField()
        {
            return reviewField;
        }

        public int GetRatingField()
        {
            return rating;
        }

        
    }
}

