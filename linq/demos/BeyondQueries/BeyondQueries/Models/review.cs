using System;
using System.Collections.Generic;

namespace BeyondQueries.Models
{
    public partial class review
    {
        public int review_id { get; set; }
        public int movie_id { get; set; }
        public string summary { get; set; }
        public int rating { get; set; }
        public string review1 { get; set; }
        public string reviewer { get; set; }
        public virtual Movie movie { get; set; }
    }
}
