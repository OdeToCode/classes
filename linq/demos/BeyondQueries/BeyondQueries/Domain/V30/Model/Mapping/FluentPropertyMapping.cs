using System;
using System.Linq.Expressions;

namespace CoreMeasures.V30.Model.Mapping.FluentInterface
{
    public static class FluentPropertyMapping
    {
        public static PropertyMapper<O1, O2> Property<O1, O2>(this PropertyMapper<O1, O2> mapper, Expression<Func<O1, object>> expression)
        {
            mapper.Entries.Add(new MapEntry<O1, O2> { Left = new PropertySpecifier<O1>(expression) });
            return mapper;
        }

        public static PropertyMapper<O1, O2> MapsTo<O1, O2>(this PropertyMapper<O1, O2> mapper, Expression<Func<O2, object>> expression)
        {
            mapper.Entries[mapper.Entries.Count - 1].Right = new PropertySpecifier<O2>(expression);
            return mapper;
        }
    }
}
