using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Movies.Domain;

namespace Movies.Models
{
    public class MovieDetailModel
    {
        public MovieDetailModel()
        {
            
        }

        public MovieDetailModel(Movie movie)
        {
            Id = movie.Id;
            Length = movie.Length;
            Director = movie.Director;
            ReviewCount = movie.Reviews.Count;
            if(ReviewCount > 0)
            {
                AverageReview = Math.Round(movie.Reviews.Average(r => r.Rating), 1);
            }
        }

        public int Id { get; set; }
        public int Length { get; set; }
        public string Director { get; set; }
        public int ReviewCount { get; set; }
        public double AverageReview { get; set; }
    }
}