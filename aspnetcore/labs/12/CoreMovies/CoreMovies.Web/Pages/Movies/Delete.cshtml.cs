using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreMovies.Data;
using CoreMovies.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoreMovies.Web.Pages.Movies
{
    public class DeleteModel : PageModel
    {
        private readonly IMovieData movieData;

        public DeleteModel(IMovieData movieData)
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

        public IActionResult OnPost(int id)
        {
            movieData.Delete(id);
            TempData["ActionMessage"] = "Deleted a movie";
            return RedirectToPage("./List");
        }
    }
}