using Grpc.Net.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SystemInfo.Client
{
    public class MemoryClient : IHostedService
    {
        private readonly IConfiguration configuration;
        private readonly ILogger logger;

        public MemoryClient(IConfiguration configuration, ILogger<MemoryClient> logger)
        {
            this.configuration = configuration;
            this.logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            logger.LogInformation($"{nameof(StartAsync)}");

            _ = Execute(cancellationToken);

            return Task.CompletedTask;
        }

        private async Task Execute(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                await GetMemoryInfo(cancellationToken);
                await Task.Delay(500, cancellationToken);
            }
        }

        private async Task GetMemoryInfo(CancellationToken cancellationToken)
        {
            logger.LogInformation(nameof(GetMemoryInfo));

            var channel = GrpcChannel.ForAddress(configuration["SystemInfoServer"]);
            var client = new SystemInfo.SystemInfoClient(channel);
            var reply = await client.GetMemoryInfoAsync(new MemoryRequest());

            Console.WriteLine($"Process: {reply.ProcessId}");
            Console.WriteLine($"WorkingSet: {reply.WorkintSet:n0}");
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            logger.LogInformation($"{nameof(StopAsync)}");
            return Task.CompletedTask;
        }
    }
}
