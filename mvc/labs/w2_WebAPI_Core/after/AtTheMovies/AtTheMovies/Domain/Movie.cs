using System.Collections.Generic;

namespace AtTheMovies.Domain
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public int Length { get; set; }
        public string Director { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }

}