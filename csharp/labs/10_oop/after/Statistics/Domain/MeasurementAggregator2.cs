using System.Collections.Generic;

namespace Domain
{
    public class MeasurementAggregator2
    {
        public MeasurementAggregator2(IList<Measurement> measurements)
        {
            _measurements = measurements;
        }

        public IEnumerable<Measurement> Aggregate(IGrouper grouper,
                                                  IAggregateCalculator calculator)
        {           
            var partitions = grouper.Group(_measurements);
            foreach (var partition in partitions)
            {
                yield return calculator.Aggregate(partition);
            }
        }


        private readonly IList<Measurement> _measurements;
    }
}