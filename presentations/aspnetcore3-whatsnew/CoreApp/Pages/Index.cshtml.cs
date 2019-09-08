using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoreApp.Pages
{
    public class IndexModel : PageModel
    {
        public Endpoint Endpoint { get; set; }

        public void OnGet()
        {
            Endpoint = HttpContext.Features.Get<IEndpointFeature>().Endpoint;
        }
    }
}
