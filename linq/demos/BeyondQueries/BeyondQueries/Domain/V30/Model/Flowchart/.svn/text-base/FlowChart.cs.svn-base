using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace CoreMeasures.V30.Model.Flowchart
{
    public class Flowchart<T, R>
    {
        public Flowchart()
        {
            Shapes = new List<Shape<T, R>>();
        }

        public void Validate()
        {
            CheckForInvalidDestinations();
            CheckForDuplicateNames();
        }

        public EvaluationResults<T, R> Evaluate(string MeasureName, T data)
        {            
            Shape<T, R> shape = Shapes[0];
            List<Shape<T, R>> visitedShapes = new List<Shape<T, R>>();
            visitedShapes.Add(shape);

            while (true)
            {
                Arrow<T> arrow = shape.Arrows.FirstOrDefault(t => t.Rule(data));
                if (arrow != null)
                {
                    if (arrow.Action != null)
                    {
                        arrow.Action(data);
                    }
                    shape = Shapes.Where(s => s.Name == arrow.PointsTo).Single();
                    visitedShapes.Add(shape);
                }
                else
                {
                    break;
                }
            }

            return ComputeEvaluationResults(MeasureName ,visitedShapes);
        }

        private EvaluationResults<T, R> ComputeEvaluationResults(string MeasureName, List<Shape<T, R>> visitedShapes)
        {
            EvaluationResults<T, R> results = new EvaluationResults<T, R>();
            Shape<T, R> lastShape = visitedShapes[visitedShapes.Count - 1];
            results.MeasureName = MeasureName;
            results.Result = lastShape.Result;
            results.RequiredFields = visitedShapes.Where(s => s.RequiredField != null)
                                                  .Select(s => s.RequiredField)
                                                  .Distinct(PropertySpecifier<T>.Comparer)
                                                  .ToList();
            return results;
        }

        public List<Shape<T, R>> Shapes { get; set; }

        private void CheckForDuplicateNames()
        {
            var duplicateShapes = Shapes.GroupBy(s => s.Name).Where(g => g.Count() > 1);
            if (duplicateShapes.Count() > 0)
            {
                string message = "The following shape names are duplicated: " +
                                 duplicateShapes.Aggregate(new StringBuilder(), (sb, s) => sb.Append(s.Key + " "), sb => sb.ToString());

                throw new InvalidOperationException(message);
            }
        }

        private void CheckForInvalidDestinations()
        {
            var names = Shapes.Select(s => s.Name);
            var problemTransitions = Shapes.SelectMany(s => s.Arrows)
                                           .Where(t => !names.Contains(t.PointsTo));
            if (problemTransitions.Count() > 0)
            {
                string message = "The following destination names are invalid: " +
                    problemTransitions.Aggregate(new StringBuilder(), (sb, t) => sb.Append(t.PointsTo + " "), sb => sb.ToString());

                throw new InvalidOperationException(message);
            }
        }
    }
}
