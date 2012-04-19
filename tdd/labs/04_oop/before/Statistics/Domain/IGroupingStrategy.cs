using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public interface IGroupingStrategy
    {
        IEnumerable<IEnumerable<Measurement>> Group(IEnumerable<Measurement> measurements);
    }

    public class SizeGroupingStrategy : IGroupingStrategy
    {
        private readonly int _groupSize;

        public SizeGroupingStrategy(int groupSize)
        {
            _groupSize = groupSize;
        }

        public IEnumerable<IEnumerable<Measurement>> 
            Group(IEnumerable<Measurement> measurements)
        {
            int total = 0;
            while (total < measurements.Count())
            {
                yield return measurements.Skip(total).Take(_groupSize);
                total += _groupSize;
            }
        }
    }
}