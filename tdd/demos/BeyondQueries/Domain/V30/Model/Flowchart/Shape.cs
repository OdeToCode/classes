using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;

namespace CoreMeasures.V30.Model.Flowchart
{
    public class Shape<T,R>
    {
        public Shape()
        {
            Arrows = new List<Arrow<T>>();
            Result = default(R);
        }
        public R Result { get; set; }        
        public string Name { get; set; }
        public PropertySpecifier<T> RequiredField { get; set; }
        public List<Arrow<T>> Arrows { get; set; }
    }
}
