using System;

namespace BeyondQueries.Models.Data
{
    public class Movie
    {        
        public string Title { get; set; }
        public DateTime? ReleaseDate { get; set; }        
        public int? Length { get; set; }
    }
}