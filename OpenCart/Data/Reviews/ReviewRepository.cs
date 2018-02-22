
using System.IO;

namespace OpenCart.Data.Reviews
{
    class ReviewRepository
    {

        private volatile static ReviewRepository instance;
        private static object lockingObject = new object();

        private ReviewRepository()
        {
        }

        public static ReviewRepository Get()
        {
            if (instance == null)
            {
                lock (lockingObject)
                {
                    if (instance == null)
                    {
                        instance = new ReviewRepository();
                    }
                }
            }
            return instance;
        }

        public IReview NotExistingUserReview()
        {
            return Review.Get()
                    .SetReviewField("This review contains more than 25 characters here")
                    .SetNameField("NotExistingUser")
                    .SetRatingField(3)
                    .Build();
        }

        public IReview AuthorizedUserReviewLengthLessThan25()
        {
            return Review.Get()
                    .SetReviewField("Less than 25 characters")
                    .SetRatingField(4)
                    .Build();
        }

        public IReview AuthorizedUserReview()
        {
            return Review.Get()
                    .SetReviewField("This review contains more than 25 characters there")
                    .SetRatingField(1)
                    .Build();
        }

        public IReview AuthorizedUserReviewLengthMoreThan1000()
        {
            return Review.Get()
                    .SetReviewField(new StreamReader(@"C:\Users\mlukastc\Source\Repos\lv283.2\OpenCart\Data\Reviews\Review.txt").ReadToEnd())
                    .SetRatingField(5)
                    .Build();
        }
    }
}
