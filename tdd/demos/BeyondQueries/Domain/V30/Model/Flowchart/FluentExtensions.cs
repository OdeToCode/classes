using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;

namespace CoreMeasures.V30.Model.Flowchart.FluentInterface
{
    public static class FluentFlowchartExtensions
    {
        public static Flowchart<T, R> WithShape<T, R>(this Flowchart<T, R> chart, string shapeName)
        {
            Shape<T, R> shape = new Shape<T, R> { Name = shapeName };
            chart.Shapes.Add(shape);
            return chart;
        }

        public static Flowchart<T, R> YieldingResult<T, R>(this Flowchart<T, R> chart, R result)
        {
            chart.LastShape().Result = result;
            return chart;
        }

        public static Flowchart<T, R> RequiresField<T, R>(this Flowchart<T, R> chart, Expression<Func<T, object>> field)
        {
            PropertySpecifier<T> specifier = new PropertySpecifier<T>(field);
            chart.LastShape().RequiredField = specifier;
            return chart;
        }

        public static Flowchart<T, R> WithArrowPointingTo<T, R>(this Flowchart<T, R> chart, string pointsTo)
        {
            Arrow<T> arrow = new Arrow<T>();
            arrow.PointsTo = pointsTo;
            chart.LastShape().Arrows.Add(arrow);
            return chart;
        }

        public static Flowchart<T, R> AndTheRule<T, R>(this Flowchart<T, R> chart, Func<T, bool> rule)
        {
            chart.LastShape().LastArrow().Rule = rule;
            return chart;
        }

        public static Flowchart<T, R> AndTheAction<T, R>(this Flowchart<T, R> chart, Action<T> action)
        {
            chart.LastShape().LastArrow().Action = action;
            return chart;
        }

        public static Shape<T, R> LastShape<T, R>(this Flowchart<T, R> chart)
        {
            return chart.Shapes[chart.Shapes.Count - 1];
        }

        public static Arrow<T> LastArrow<T, R>(this Shape<T, R> shape)
        {
            return shape.Arrows[shape.Arrows.Count - 1];
        }
    }
}
