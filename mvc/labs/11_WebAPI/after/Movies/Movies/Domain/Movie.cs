using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Movies.Domain
{
    public class Movie
    {
        public virtual int Id { get; set; }
        public virtual string Title { get; set; }
        public virtual int Year { get; set; }
        public virtual int Length { get; set; }
        public virtual string Director { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}