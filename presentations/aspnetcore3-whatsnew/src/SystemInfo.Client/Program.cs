using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System.Threading;
using Grpc.Net.Client;
using System;

namespace SystemInfo.Client
{
    class GreeterClient : IHostedService
    {
        private readonly IConfiguration configuration;
        private readonly ILogger<GreeterClient> logger;

        public GreeterClient(IConfiguration configuration, ILogger<GreeterClient> logger)
        {
            this.configuration = configuration;
            this.logger = logger;
            this.logger.LogDebug(nameof(GreeterClient));
            Console.WriteLine("FUCK");
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            logger.LogDebug(nameof(StartAsync));
            while(!cancellationToken.IsCancellationRequested)
            {
                await GetGreeting(cancellationToken);
                await Task.Delay(5000, cancellationToken);
            }
        }

        public async Task GetGreeting(CancellationToken  cancellationToken)
        {
            logger.LogDebug(nameof(GetGreeting));
            var channel = GrpcChannel.ForAddress(configuration["SystemInfoServer"]);
            var client = new Greeter.GreeterClient(channel);
            var reply = await client.SayHelloAsync(new HelloRequest { Name = "Scott" }, cancellationToken: cancellationToken);
            Console.WriteLine(reply);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }

    class Program
    {
        static async Task Main(string[] args)
        {
            var builder = new HostBuilder()
               .ConfigureAppConfiguration((hostingContext, config) =>
               {
                   config.AddJsonFile("appsettings.json", optional: true);
                   config.AddEnvironmentVariables();
                   config.AddCommandLine(args);
               })
               .ConfigureLogging((hostingContext, logging) => {
                   logging.AddConsole();
               })
               .ConfigureServices(services =>
               {
                   services.AddHostedService<GreeterClient>();
               });
            await builder.Build().RunAsync();
            
        }
    }
}
