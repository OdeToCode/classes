using System;
using System.Threading;

namespace Workplace
{
    public class PayrollServices
    {
        public decimal GetPayrollDeduction(Employee employee)
        {
            Console.WriteLine("Executing GetPayrollDeduction for employee {0}", employee.EmployeeID);

            var rand = new Random(DateTime.Now.Millisecond);
            var delay = rand.Next(1, 5);
            var count = 0;
            var process = true;

            while (process)
            {
                Thread.Sleep(1000);
                count++;
                if (count >= delay)
                    process = false;
            }

            return delay;
        }        
    }
}