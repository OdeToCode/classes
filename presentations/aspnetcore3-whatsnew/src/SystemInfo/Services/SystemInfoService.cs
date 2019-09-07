using Grpc.Core;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SystemInfo.Services
{
    public class SystemInfoService : SystemInfo.SystemInfoBase
    {
        private readonly ILogger logger;

        public SystemInfoService(ILogger<SystemInfoService> logger)
        {
            this.logger = logger;
        }

        public override Task<MemoryResponse> GetMemoryInfo(MemoryRequest request, ServerCallContext context)
        {
            logger.LogInformation(nameof(GetMemoryInfo));

            var process = Process.GetCurrentProcess();
            _ = new byte[8192];
            var result = new MemoryResponse
            {
                 ProcessId = process.Id,
                 WorkintSet = process.WorkingSet64
            };
            return Task.FromResult(result);
        }
    }
}
