using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class ModalCalculator : IAggregateCalculator
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
}