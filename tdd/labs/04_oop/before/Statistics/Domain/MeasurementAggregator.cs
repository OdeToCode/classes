using System;
using System.Linq;
using System.Collections.Generic;

namespace Domain
{
    public class MeasurementAggregator
    {       
        public MeasurementAggregator(IList<Measurement> measurements)
        {
            _measurements = measurements;
        }

        public IEnumerable<Measurement> Aggregate(
            IGroupingStrategy groupingStrategy, 
            IMeasurementAggregator aggregator)
        {

            var partitions = groupingStrategy.Group(_measurements);
            foreach (var partition in partitions)
            {
                yield return aggregator.Aggregate(partition);
            }
        }
       
        private readonly IList<Measurement> _measurements;
    }
}