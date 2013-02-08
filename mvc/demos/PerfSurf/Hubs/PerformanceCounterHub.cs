using System.Threading;
using PerfSurf.PerfCounters;
using SignalR;
using SignalR.Hosting.AspNet;
using SignalR.Hubs;
using SignalR.Infrastructure;

namespace PerfSurf.Hubs
{
    [HubName("performanceCounter")]
    public class PerformanceCounterHub : Hub
    {
        private Timer _timer;
        private PerformanceCounterQueryExecutor _executor;

        public PerformanceCounterHub()
        {
            var queries = new DefaultCounters().Queries;

            _executor = new PerformanceCounterQueryExecutor(queries);
            _timer = new Timer(UpdateCounters, null, 2000, 2000);
        }

        public bool connect()
        {
            return true;
        }

        private void UpdateCounters(object state)
        {
            var results = _executor.Execute();
            CounterClients.updateCounters(results);
        }

        private static dynamic CounterClients
        {
            get
            {
                return AspNetHost.DependencyResolver
                    .Resolve<IConnectionManager>()
                    .GetClients<PerformanceCounterHub>();
            }
        }
    }
}