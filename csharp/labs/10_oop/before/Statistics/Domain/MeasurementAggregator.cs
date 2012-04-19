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

        public IEnumerable<Measurement> Aggregate(int groupSize, AggregationType type)
        {
            var partitions = PartitionMeasurements(groupSize);
            foreach (var partition in partitions)
            {
                yield return Aggregate(partition, type);
            }
        }

        private Measurement Aggregate(IEnumerable<Measurement> measurements, AggregationType type)
        {
            Measurement result = null;
            switch(type)
            {               
                case AggregationType.Mode:
                        result = Mode(measurements);
                    break;

            }
            return result;
        }

        private Measurement Mode(IEnumerable<Measurement> measurements)
        {
            var highValue = measurements.GroupBy(m => m.HighValue)
                                        .OrderByDescending(g => g.Count())
                                        .Select(g => g.Key).FirstOrDefault();

            var lowValue = measurements.GroupBy(m => m.LowValue)
                                       .OrderByDescending(g => g.Count())
                                       .Select(g => g.Key).FirstOrDefault();

            return new Measurement()
                       {
                           HighValue = highValue,
                           LowValue = lowValue
                       };
        }

        private IEnumerable<IEnumerable<Measurement>> PartitionMeasurements(int groupSize)
        {
            int total = 0;
            while(total < _measurements.Count)
            {
                yield return _measurements.Skip(total).Take(groupSize);
                total += groupSize;
            }
        }

        private readonly IList<Measurement> _measurements;
    }
}