using System;
using System.Collections.Generic;

namespace BeyondQueries.Models
{
    public partial class movie
    {
        public movie()
        {
            this.reviews = new List<review>();
        }

        public int movie_id { get; set; }
        public string title { get; set; }
        public System.DateTime release_date { get; set; }
        public string subtitle { get; set; }
        public byte[] version { get; set; }
        public virtual ICollection<review> reviews { get; set; }
    }
}
