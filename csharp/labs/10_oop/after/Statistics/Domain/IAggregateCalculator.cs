using System.Collections.Generic;

namespace Domain
{
    public interface IAggregateCalculator
    {
        Measurement Aggregate(IEnumerable<Measurement> measurements);
    }
}