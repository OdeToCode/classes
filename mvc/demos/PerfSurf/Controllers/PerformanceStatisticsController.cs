using System.Collections.Generic;
using System.Web.Http;
using PerfSurf.PerfCounters;

namespace PerfSurf.Controllers
{
    public class PerformanceStatisticsController : ApiController
    {
        public IEnumerable<PerformanceCounterResult> Get()
        {
            var counters = new DefaultCounters();
            var executor = new PerformanceCounterQueryExecutor(counters.Queries);
            return executor.Execute();
        }        
    }   
}
