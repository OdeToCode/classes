using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Movies.Models
{
    public class MovieMetadata
    {
        [DisplayName("Release")]
        [DisplayFormat(DataFormatString = "{0:g}")]
        public DateTime ReleaseDate { get; set; }
    }
}