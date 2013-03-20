using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AtTheMovies.Handlers
{
    public class ConsoleLoggingHandler : DelegatingHandler
    {
        protected async override Task<HttpResponseMessage> 
            SendAsync(HttpRequestMessage request, 
            CancellationToken cancellationToken)
        {
            LogRequest(request);           
            var response = await base.SendAsync(request, cancellationToken);
            LogResponse(response);
            return response;
        }

        private void LogResponse(HttpResponseMessage response)
        {
            var contentType = response.Content.Headers.ContentType.MediaType;
            Console.WriteLine("Response with {0}", contentType);
        }

        private void LogRequest(HttpRequestMessage request)
        {
            var mediaType = "none";
            var accept = request.Headers.Accept.FirstOrDefault();
            if(accept != null)
            {
                mediaType = accept.MediaType;
            }
           Console.WriteLine("Request for {0}", mediaType);
        }
    }
}
