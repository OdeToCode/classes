using System.Collections.Generic;
using CoreMovies.Data;
using CoreMovies.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoreMovies.Web.Pages.Movies
{
    public class ListModel : PageModel
    {
        public IEnumerable<Movie> Movies { get; private set; }

        private readonly IMovieData movieData;

        public ListModel(IMovieData movieData)
        {
            this.movieData = movieData;
        }

        public void OnGet()
        {
            Movies = movieData.GetAll();
        }

        public void OnPost()
        {
            // take data from user
        }
    }
}