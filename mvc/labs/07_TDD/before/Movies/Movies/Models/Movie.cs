using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Movies.Models
{
    [MetadataType(typeof(MovieMetadata))]
    public partial class Movie
    {
        [DisplayName("Average Rating")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public double AverageReview
        {
            get
            {
                return Reviews.Average(r => r.Rating);
            }
        }
    }
}