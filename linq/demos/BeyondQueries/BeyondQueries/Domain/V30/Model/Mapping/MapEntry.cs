using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoreMeasures.V30.Model
{
    public class MapEntry<O1, O2>
    {
        public PropertySpecifier<O1> Left;
        public PropertySpecifier<O2> Right;
    }
}
