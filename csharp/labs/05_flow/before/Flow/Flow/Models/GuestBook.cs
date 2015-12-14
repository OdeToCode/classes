using System.Collections.Generic;

namespace Flow.Models
{
    public class GuestBook
    {
        public IEnumerable<Guest> GetGuests()
        {
            return _guests;
        }

        public void AddGuest(Guest newGuest)
        {
            _guests.Add(newGuest);
        }

        private static List<Guest> _guests = new List<Guest>
                                                {
                                                    new Guest { Name="Frank", Message="Hi!"},
                                                    new Guest { Name="Joy"},
                                                    new Guest {Name="Susan", Message="Hello!"}
                                                };
    }
}