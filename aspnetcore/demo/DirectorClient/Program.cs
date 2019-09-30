using Grpc.Net.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DirectorClient
{

    public class DirectorPollingClient : IHostedService
    {
        private readonly ILogger<DirectorPollingClient> logger;
        private readonly IConfiguration configuration;

        public DirectorPollingClient(ILogger<DirectorPollingClient> logger,
                                    IConfiguration configuration)
        {
            this.logger = logger;
            this.configuration = configuration;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            logger.LogInformation($"{nameof(DirectorPollingClient)} is starting");

            _ = DoExecute(cancellationToken);

            return Task.CompletedTask;

        }

        async Task DoExecute(CancellationToken cancellationToken)
        {
            while (true)
            {
                logger.LogInformation($"Cancel token is {cancellationToken.IsCancellationRequested}");
                var channel = GrpcChannel.ForAddress(configuration["Server"]);
                var client = new Movies.Protos.Directors.DirectorsClient(channel);
                var result = client.FetchAllDirectors(new Movies.Protos.DirectorRequest());
                Console.WriteLine($"{result.Name} : {result.Country}");
                await Task.Delay(2000, cancellationToken);
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            logger.LogInformation($"{nameof(DirectorPollingClient)} is stopping");
            return Task.CompletedTask;
        }
    }


    class Program
    {
        static async Task Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args)
                            .ConfigureLogging(log =>
                            {
                                log.AddConsole();
                                log.SetMinimumLevel(LogLevel.Information);
                            })
                            .ConfigureAppConfiguration(c =>
                            {
                                c.AddJsonFile("appSettings.json", true);
                            })
                            .ConfigureServices(s =>
                            {
                                s.AddHostedService<DirectorPollingClient>();
                            });
            await host.RunConsoleAsync();
        }
    }
}
