using System;
using System.Data.Entity;
using EmployeeTimeCards.Core;

namespace EmployeeTimeCards.Web.Infrastructure
{
    public class TimeCardContextInitializer : IDatabaseInitializer<TimeCardContext>
    {
        public void InitializeDatabase(TimeCardContext context)
        {
            context.Database.CreateIfNotExists();

            var date = new DateTime(2012, 1, 1);
            var endDate = new DateTime(2015, 12, 31);
            while(date < endDate)
            {
                context.PayPeriods.Add(new PayPeriod {StartDate = date});
                date = date.AddMonths(1);
            }
            context.SaveChanges();
        }
    }
}