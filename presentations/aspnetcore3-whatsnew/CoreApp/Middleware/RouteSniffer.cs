using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace CoreApp.Middleware
{
    public class RouteSniffer
    {
        private readonly RequestDelegate next;
        private readonly ILogger<RouteSniffer> logger;

        public RouteSniffer(RequestDelegate next, ILogger<RouteSniffer> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            var feature = context.Features.Get<IEndpointFeature>();
            
            logger.LogInformation($"{feature.Endpoint.DisplayName}");
            foreach(var data in feature.Endpoint.Metadata) 
            {
                logger.LogInformation($"{ data.GetType().ToString()}");
            }

            await next(context);
        }
    }
}
