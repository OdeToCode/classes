using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public interface IMeasurementAggregator
    {
        Measurement Aggregate(IEnumerable<Measurement> measurements);
    }

    public class ModeAggregator: IMeasurementAggregator
    {
        public Measurement Aggregate(IEnumerable<Measurement> measurements)
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
    }

    public class MeanAggregator : IMeasurementAggregator
    {
        public Measurement Aggregate(
            IEnumerable<Measurement> measurements)
        {
            var highValue = measurements.Average(m => m.HighValue);
            var lowValue = measurements.Average(m => m.LowValue);
            return new Measurement()
            {
                HighValue = highValue,
                LowValue = lowValue
            };
        }
    }

    public enum AggregationType
    {
        Mean, 
        Mode
    }
}