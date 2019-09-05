using System;
using CoreMovies.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using CoreMovies.Data;

namespace CoreMovies.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IMovieData movieData;

        public string Message { get; protected set; }
        public int MovieCount { get; set; }

        public IndexModel(IOptions<Greetings> greetings, IMovieData movieData)
        {
            MovieCount = movieData.Count();
            if(DateTime.UtcNow.Hour > 12) {
                Message = greetings.Value.Evening;
            }
            else {
                Message = greetings.Value.Morning;
            }

            this.movieData = movieData;
        }

        public void OnGet()
        {

        }
    }
}
