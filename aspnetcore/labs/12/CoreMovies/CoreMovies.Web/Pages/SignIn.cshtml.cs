using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoreMovies.Pages
{
    public class SignInModel : PageModel
    {
        public async Task<IActionResult> OnGet()
        {
            if (!HttpContext.User.Identities.Any(identity => identity.IsAuthenticated))
            {
                var user = new ClaimsPrincipal(new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, "Scott") }, 
                                               CookieAuthenticationDefaults.AuthenticationScheme));
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, user);

                return RedirectToPage("/SignIn");
            }
            return Page();
        }
    }
}