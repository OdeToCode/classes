using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreMovies.Web.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

namespace CoreMovies.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly Greetings greetings;

        public string Message { get; set; }

        public IndexModel(IOptions<Greetings> greetings)
        {
            this.greetings = greetings.Value;
        }

        public void OnGet()
        {
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
