using System;
namespace MovieReviews.Model
{
    partial class MovieDB
    {
    }

    partial class Review
    {                     
        partial void OnRatingChanging(int value)
        {
            if (value < 1 || value > 10)
            {
                throw new ArgumentException("Rating must be between 1 and 10");
            }
        }
    }

}
