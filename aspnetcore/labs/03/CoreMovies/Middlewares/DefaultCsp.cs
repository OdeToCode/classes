using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace CoreMovies.Web.Middlewares
{
    public class DefaultCsp
    {
        private readonly RequestDelegate next;

        public DefaultCsp(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            context.Response.Headers["Content-Security-Policy"] = "frame-ancestors 'none'";
            await next(context);
        }
    }
}
