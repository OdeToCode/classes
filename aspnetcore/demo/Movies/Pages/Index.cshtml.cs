using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Movies.Models;

namespace Movies.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IConfiguration configuration;

        public IndexModel(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string Message { get; set; }

        [BindProperty]
        public Movie Movie { get; set; }

        public void OnGet()
        {
            Message = configuration["Greeting"] ?? "NO message";
        }

        public void OnPost()
        {

        }
    }
}