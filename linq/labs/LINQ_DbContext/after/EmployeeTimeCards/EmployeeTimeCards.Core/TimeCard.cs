namespace EmployeeTimeCards.Core
{
    public class TimeCard
    {
        public virtual int Id { get; set; }
        public virtual int Hours { get; set; }
        public virtual PayPeriod Period { get; set; }
        public virtual Employee Employee { get; set; }
    }
}