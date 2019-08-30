using System;
using CoreMovies.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CoreMovies.Pages
{
    public class IndexModel : PageModel
    {
        public string Message { get; protected set; }

        public IndexModel(IOptions<Greetings> greetings)
        {
            if(DateTime.UtcNow.Hour > 12) {
                Message = greetings.Value.Evening;
            }
            else {
                Message = greetings.Value.Morning;
            }
        }

        public void OnGet()
        {

        }
    }
}
