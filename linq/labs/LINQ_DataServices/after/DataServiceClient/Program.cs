using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataServiceClient.MovieReviewDataService;

namespace DataServiceClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri serviceRoot = new Uri(
                "http://localhost.:8080/WebSite/MovieReviews.svc");
            MovieRepository repository = new MovieRepository(serviceRoot);
            repository.Credentials = 
                System.Net.CredentialCache.DefaultCredentials;


            var mostRecentMovies =
                (from m in repository.Movies.Expand("Reviews")
                 orderby m.ReleaseDate descending
                 select m).Take(10);

            foreach (var movie in mostRecentMovies)
            {
                Console.WriteLine(movie.Title);
                foreach (var review in movie.Reviews)
                {
                    Console.WriteLine(review.Body);
                }
            }

            var firstReview = mostRecentMovies.First().Reviews.First();
            firstReview.Rating = firstReview.Rating + 1;

            repository.SaveChanges();



        }
    }
}
