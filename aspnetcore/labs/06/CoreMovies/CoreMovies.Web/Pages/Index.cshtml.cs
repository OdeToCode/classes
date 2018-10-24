using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreMovies.Data;
using CoreMovies.Web.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CoreMovies.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly Greetings greetings;
        private readonly ILogger logger;
        private readonly IMovieData movieData;

        public string Message { get; set; }
        public int MovieCount { get; set; }

        public IndexModel(IOptions<Greetings> greetings,
                          ILogger<IndexModel> logger,
                          IMovieData movieData)
        {
            this.greetings = greetings.Value;
            this.logger = logger;
            this.movieData = movieData;
        }

        public void OnGet()
        {
            logger.LogInformation($"Executing {nameof(OnGet)}");

            MovieCount = movieData.Count();

            if (DateTime.Now.Hour <= 12)
            {
                Message = greetings.Morning;
            }
            else
            {
                Message = greetings.Evening;
            }
        }
    }
}
