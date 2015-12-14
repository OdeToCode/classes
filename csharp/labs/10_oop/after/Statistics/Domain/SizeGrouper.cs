using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class SizeGrouper : IGrouper
    {
        public SizeGrouper(int size)
        {
            _size = size;
        }

        public IEnumerable<IEnumerable<Measurement>> Group(
            IList<Measurement> measurements)
        {
            int total = 0;
            while (total < measurements.Count)
            {
                yield return measurements.Skip(total).Take(_size);
                total += _size;
            }
        }

        private readonly int _size;
    }
}