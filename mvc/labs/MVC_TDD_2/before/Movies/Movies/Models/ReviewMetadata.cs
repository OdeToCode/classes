using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Movies.Models
{
    public class ReviewMetadata
    {
        [Required]
        [Range(1, 10, ErrorMessage="Rate the movie from 1 to 9")]
        public int Rating { get; set; }

        [Required]
        [MaxWords(3, ErrorMessage = "Too many words!")]
        public string Summary { get; set; }
    }

}