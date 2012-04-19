using System;
using System.Collections.Generic;
using System.Linq;

namespace BeyondQueries.Models.Data
{
    public class ValidationRule<T>
    {
        public Func<T, bool> Rule { get; set; }
        public string ValidationMessage { get; set; }
    }

    public class ValidationResult
    {
        public ValidationResult(IEnumerable<string> messages)
        {
            ValidationMessages = new List<string>(messages);
        }

        private List<string> ValidationMessages { get; set; }
    }


    public class MovieValidator
    {
        public ValidationResult Validate(Movie movie)
        {
            var rules = CreateRules();

            var failedMessages =
                rules.Where(r => r.Rule(movie) == false)
                     .Select(r => r.ValidationMessage);

            return new ValidationResult(failedMessages);
        }

        private static ValidationRule<Movie>[] CreateRules()
        {
            ValidationRule<Movie>[] rules =
                {
                    new ValidationRule<Movie>
                        {
                            Rule = m => m.Title != null,
                            ValidationMessage = "Title cannot be null"
                        },
                    new ValidationRule<Movie>
                        {
                            Rule = m => m.Title.Length > 0,
                            ValidationMessage = "Title cannot be empty"
                        },
                    new ValidationRule<Movie>
                        {
                            Rule = m => m.ReleaseDate.Value.Year > 1920,
                            ValidationMessage = "Year is too early"
                        },
                    new ValidationRule<Movie>
                        {
                            Rule = m => m.ReleaseDate.Value.Year < DateTime.Now.Year,
                            ValidationMessage = "Year is too late"
                        }
                };
            return rules;
        }
    }
}