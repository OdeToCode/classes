using CoreMovies.Data;
using CoreMovies.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoreMovies.Web.Pages.Movies
{
    public class EditModel : PageModel
    {
        private readonly IMovieData movieData;

        public EditModel(IMovieData movieData)
        {
            this.movieData = movieData;
        }

        [BindProperty]
        public Movie Movie { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id.HasValue)
            {
                Movie = movieData.GetById(id.Value);
            }
            else
            {
                Movie = new Movie();
            }
            if (Movie == null)
            {
                return NotFound();
            }
            return Page();
        }

        public IActionResult OnPost(int? id)
        {
            if (ModelState.IsValid)
            {
                if (Movie.Id > 0)
                {
                    Movie = movieData.Update(Movie);
                }
                else
                {
                    Movie = movieData.Add(Movie);
                }
                movieData.Commit();
                return RedirectToPage("./Detail", new { id = Movie.Id });

            }
            return Page();
        }
    }
}