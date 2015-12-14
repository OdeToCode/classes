using System.Collections.Generic;
using System.Linq;
using EmployeeTimeCards.Core;

namespace EmployeeTimeCards.Tests
{
    public class FakeEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employees = new List<Employee>();

        public Employee Find(int id)
        {
            return _employees.First(e => e.Id == id);
        }

        public IEnumerable<Employee> FindAll()
        {
            return _employees;
        }

        public void Add(Employee newEmployee)
        {
            _employees.Add(newEmployee);
        }

        public void Update(Employee employee)
        {
            
        }

        public void Delete(int id)
        {
            _employees.Remove(Find(id));
        }
    }
}