using System;

namespace EmployeeTimeCards.Core
{
    public class PayPeriod
    {
        public virtual int Id { get; set; }
        public virtual DateTime StartDate { get; set; }        
    }
}