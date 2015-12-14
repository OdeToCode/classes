using System;

namespace Functional
{
    public class MovieValidationRule
    {
        public MovieValidationRule(Func<Movie, bool> predicate, 
                                   string message)
        {
            Predicate = predicate;
            Error = new ValidationError(message);
        }

        public Func<Movie, bool> Predicate { get; set; }
        public ValidationError Error { get; set; }
    }
}