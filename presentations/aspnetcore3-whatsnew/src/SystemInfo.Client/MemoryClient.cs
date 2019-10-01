using Grpc.Net.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SystemInfo.Client
{
    public class MemoryClient : BackgroundService
    {
        private readonly IConfiguration configuration;
        private readonly ILogger logger;

        public MemoryClient(IConfiguration configuration, ILogger<MemoryClient> logger)
        {
            this.configuration = configuration;
            this.logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await GetMemoryInfo(stoppingToken);
                await Task.Delay(500, stoppingToken);
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
    }
}
