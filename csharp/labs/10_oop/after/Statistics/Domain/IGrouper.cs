using System.Collections.Generic;

namespace Domain
{
    public interface IGrouper
    {
        IEnumerable<IEnumerable<Measurement>> Group(IList<Measurement> measurements);
    }
}