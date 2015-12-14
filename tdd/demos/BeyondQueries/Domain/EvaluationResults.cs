using System.Collections.Generic;

namespace BeyondQueries.Domain
{
    public class EvaluationResults<T, R>
    {
        public R Result { get; set; }
        public List<PropertySpecifier<T>> RequiredFields { get; set; }
    }
}