using System;
using System.Collections.Generic;
using System.Linq;

namespace Functional
{
    public class Movie
    {
        public Movie()
        {
            ReleaseDate = SystemTime.Now();
        }

        public string Title { get; set; }
        public int Duration { get; set; }
        public DateTime ReleaseDate { get; set; }

        public IEnumerable<ValidationError> Validate()
        {
            return Rules.Where(r => r.Predicate(this)).Select(r => r.Error);
        }

        IEnumerable<MovieValidationRule> Rules
        {
            get
            {
                yield return new MovieValidationRule
                    (
                        m => String.IsNullOrEmpty(m.Title),
                        "Title cannot be empty"
                    );
                yield return new MovieValidationRule
                    (
                        m => m.Duration < 45 || m.Duration > 240,
                        "The duration is out of range"
                    );

                yield return new MovieValidationRule
                    (
                        m=>m.ReleaseDate.Year < 1860 || m.ReleaseDate.Year > 2100,
                        "The release date is out of range"
                    );
            }
        }
    }
}