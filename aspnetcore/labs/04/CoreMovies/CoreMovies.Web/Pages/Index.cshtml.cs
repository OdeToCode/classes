using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public string Message { get; set; }

        public IndexModel(IOptions<Greetings> greetings,
                          ILogger<IndexModel> logger)
        {
            this.greetings = greetings.Value;
            this.logger = logger;
        }

        public void OnGet()
        {
            logger.LogInformation($"Executing {nameof(OnGet)}");

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
