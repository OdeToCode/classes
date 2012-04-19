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
        [Range(1, 10)]
        public int Rating { get; set; }
    }

}