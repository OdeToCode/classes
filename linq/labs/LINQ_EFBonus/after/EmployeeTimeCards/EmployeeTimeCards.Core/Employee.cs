using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmployeeTimeCards.Core
{
    public class Employee
    {
        public virtual int Id { get; set; }     
        [Required]
        public virtual string FirstName { get; set; }
        [Required]
        public virtual string LastName { get; set; }
        public virtual DateTime HireDate { get; set; }
        public virtual string EmailAddress { get; set; }
        public virtual ICollection<TimeCard> TimeCards { get; set; }        
    }
}