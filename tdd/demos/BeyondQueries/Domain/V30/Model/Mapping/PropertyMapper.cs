using System;
using System.Collections.Generic;

namespace CoreMeasures.V30.Model
{
    public class PropertyMapper<O1, O2>
    {
        public PropertyMapper()
        {
            Entries = new List<MapEntry<O1, O2>>();
        }

        public void ForEach(Action<PropertySpecifier<O1>, PropertySpecifier<O2>> action)
        {
            foreach (var entry in Entries)
            {
                action(entry.Left, entry.Right);
            }
        }

        public List<MapEntry<O1,O2>> Entries { get; set; }
    }
}
