using CoreMovies.Data;
using CoreMovies.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoreMovies.Web.Pages.Movies
{
    public class DetailModel : PageModel
    {
        private readonly IMovieData movieData;

        public DetailModel(IMovieData movieData)
        {
            this.movieData = movieData;
        }

        public Movie Movie { get; private set; }

        public IActionResult OnGet(int id)
        {
            Movie = movieData.GetById(id);
            if(Movie == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}