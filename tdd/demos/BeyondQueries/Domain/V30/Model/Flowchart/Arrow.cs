using System;

namespace CoreMeasures.V30.Model.Flowchart
{
    public class Arrow<T>
    {
        public string PointsTo { get; set; }
        public Func<T, bool> Rule { get; set; }
        public Action<T> Action { get; set; }
    }
}
