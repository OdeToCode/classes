using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
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
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            logger.LogDebug(nameof(StartAsync));
            _ = Execute(cancellationToken);
            return Task.CompletedTask;
        }

        private async Task Execute(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
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
}
