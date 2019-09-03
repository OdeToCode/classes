using System.ComponentModel.DataAnnotations;

namespace CoreMovies.Entities
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(80)]
        public string Name { get; set; }

        [Range(1800, 2100)]
        public int Year { get; set; }
    }
}
