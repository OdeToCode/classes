using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Controllers.Models
{
    public class GuestBook
    {
        public IEnumerable<GuestEntry> Entries
        {
            get { return _entries; }
        }

        public void Add(GuestEntry entry)
        {
            if (entry.Name == "Fido")
            {
                throw new InvalidOperationException("No dogs allowed");
            }

            _entries.Add(entry);
        }

        static List<GuestEntry> _entries = new List<GuestEntry>();
    }

}