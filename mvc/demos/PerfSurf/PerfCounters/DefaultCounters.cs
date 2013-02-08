using System.Collections.Generic;

namespace PerfSurf.PerfCounters
{
    public class DefaultCounters
    {
        public IEnumerable<PerformanceCounterQuery> Queries
        {
            get { return _queries; }
        }

        private static List<PerformanceCounterQuery> _queries =
            new List<PerformanceCounterQuery>
                {
                    new PerformanceCounterQuery("Processor", "Processor", "% Processor Time", "_Total"),
                    new PerformanceCounterQuery("Paging", "Memory", "Pages/sec"),
                    new PerformanceCounterQuery("Disk", "PhysicalDisk", "% Disk Time", "_Total")
                };
    }
}