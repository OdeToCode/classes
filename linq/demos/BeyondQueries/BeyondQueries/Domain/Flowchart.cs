using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeyondQueries.Domain
{
    public class Flowchart<T, TResult>
    {
        public Flowchart()
        {
            Shapes = new List<Shape<T, TResult>>();
        }

        public void Validate()
        {
            CheckForInvalidDestinations();
            CheckForDuplicateNames();
        }

        public EvaluationResults<T, TResult> Evaluate(T data)
        {
            Shape<T, TResult> shape = Shapes[0];
            var visitedShapes = new List<Shape<T, TResult>> {shape};

            while (true)
            {
                Arrow<T> arrow = shape.Arrows
                                      .FirstOrDefault(t => t.Rule != null && t.Rule(data));
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

            return ComputeEvaluationResults(visitedShapes);
        }

        private EvaluationResults<T, TResult> ComputeEvaluationResults(List<Shape<T, TResult>> visitedShapes)
        {
            var results = new EvaluationResults<T, TResult>();
            var lastShape = visitedShapes[visitedShapes.Count - 1];            
            results.Result = lastShape.Result;
            results.RequiredFields = visitedShapes.Where(s => s.RequiredField != null)
                                                  .Select(s => s.RequiredField)
                                                  .Distinct(PropertySpecifier<T>.Comparer)
                                                  .ToList();
            return results;
        }

        public List<Shape<T, TResult>> Shapes { get; set; }

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