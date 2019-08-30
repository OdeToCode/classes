using CoreMovies.Web.Middlewares;

namespace Microsoft.AspNetCore.Builder
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseDefaultCsp(this IApplicationBuilder app)
        {
            app.UseMiddleware<DefaultCsp>();
            return app;
        }
    }
}
