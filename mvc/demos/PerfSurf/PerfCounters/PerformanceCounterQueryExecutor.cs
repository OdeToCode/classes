using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace PerfSurf.PerfCounters
{
    public class PerformanceCounterQueryExecutor
    {        
        public PerformanceCounterQueryExecutor(
            IEnumerable<PerformanceCounterQuery> queries)
        {
            _queries = queries;
        }

        public virtual IEnumerable<PerformanceCounterResult> Execute()
        {
            var result =
                (from query in _queries
                 let counter = GetCounterFor(query)
                 select new PerformanceCounterResult
                 {
                     Name = query.FriendlyName,
                     Value = counter.NextValue(),
                 }).ToList();
            
            return result;
        }

        private PerformanceCounter GetCounterFor(PerformanceCounterQuery query)
        {            
            var counter = _counters.GetOrAdd(query.LookupName,
                         (_) => query.GetCounter());
            return counter;
        }

        private readonly IEnumerable<PerformanceCounterQuery> _queries;
        private static readonly ConcurrentDictionary<string, PerformanceCounter> _counters = new ConcurrentDictionary<string, PerformanceCounter>();
    }
}