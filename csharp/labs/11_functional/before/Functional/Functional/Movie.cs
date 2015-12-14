using System;
using System.Collections.Generic;

namespace Functional
{
    public class Movie
    {
        public string Title { get; set; }
        public int Duration { get; set; }
        public DateTime ReleaseDate { get; set; }

        public IEnumerable<ValidationError> Validate()
        {
            if(String.IsNullOrEmpty(Title))
            {
                yield return new ValidationError("Title cannot be empty");
            }
            if(Duration < 45 || Duration > 240)
            {
                yield return new ValidationError("Duration out of range");
            }
            if(ReleaseDate.Year < 1860 || ReleaseDate.Year > 2100)
            {
                yield return new ValidationError("Release date our of range");
            }
        }
    }
}