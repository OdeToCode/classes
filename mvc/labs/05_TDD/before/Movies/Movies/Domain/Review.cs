using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Movies.Domain
{
    public class Review
    {
        public virtual int Id { get; set; }

        [Range(1,10)]
        public virtual int Rating { get; set; }

        [Required]
        [StringLength(255)]
        public virtual string Reviewer { get; set; }

        [Required]
        [StringLength(2048)]
        [DataType(DataType.MultilineText)]
        public virtual string Summary { get; set; }

        public virtual Movie Movie { get; set; }
    }
}