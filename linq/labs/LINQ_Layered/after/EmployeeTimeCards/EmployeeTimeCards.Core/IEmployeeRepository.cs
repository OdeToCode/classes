using System.Collections.Generic;

namespace EmployeeTimeCards.Core
{
    public interface IEmployeeRepository
    {
        Employee Find(int id);
        IEnumerable<Employee> FindAll();
        void Add(Employee newEmployee);
        void Update(Employee employee);
        void Delete(int id);
    }
}