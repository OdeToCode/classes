using System;
using System.Diagnostics;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;

namespace Workplace
{
    class Program
    {
        static void Main()
        {            
            var watch = Stopwatch.StartNew();

            UseTask();          

            Console.WriteLine("Total time: {0}s", watch.Elapsed.TotalSeconds);
        }

        private static void UseTask()
        {
            var service = new PayrollServices();
            var employees = new EmployeeList();

            var task1 = Task.Factory.StartNew(() => service.GetPayrollDeduction(employees[0]));
            var task4 = task1.ContinueWith(t =>
                                  {                                      
                                      Console.WriteLine(t.Result);
                                  });

            var task2 = Task.Factory.StartNew(() => service.GetPayrollDeduction(employees[1]));
            var task3 = Task.Factory.StartNew(() => service.GetPayrollDeduction(employees[2]));


            Task.WaitAll(task1, task2, task3, task4);
        }

        private static void WalkTree()
        {
            var tree = new EmployeeHierarchy();
            WalkTree(tree);
        }

        private static void WalkTree(Tree<Employee> node)
        {
            if (node == null) return;           
            if (node.Data != null)
            {
                Employee employee = node.Data;
                Console.WriteLine("Starting employee id {0}", employee.EmployeeID);
                decimal span = new PayrollServices()
                                   .GetPayrollDeduction(employee);                
                Console.WriteLine("Completed process for employee id {0} took {1}s",
                    employee.EmployeeID, span);
                Console.WriteLine();
            }

            Parallel.Invoke(() => WalkTree(node.Left),
                            () => WalkTree(node.Right));            
        }

        private static void ProcessEmployees()
        {
            var employees = new EmployeeList();            
            var service = new PayrollServices();
            Parallel.ForEach(employees, e => 
            {
                Console.WriteLine("Starting employee id {0}", e.EmployeeID);

                var span = service.GetPayrollDeduction(e);

                Console.WriteLine("Completed process for employee id {0} took {1}s",
                    e.EmployeeID, span);
            });
        }
    }
}
