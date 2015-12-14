using System.Collections.Generic;
using System.Data;
using System.Linq;
using EmployeeTimeCards.Core;

namespace EmployeeTimeCards.Web.Infrastructure
{
    public class SqlEmployeeRepository : IEmployeeRepository
    {
        private readonly TimeCardContext _db;

        public SqlEmployeeRepository(TimeCardContext db)
        {
            _db = db;
        }

        public Employee Find(int id)
        {
            return _db.Employees.Find(id);
        }

        public IEnumerable<Employee> FindAll()
        {
            return _db.Employees.ToList();
        }

        public void Add(Employee newEmployee)
        {
            _db.Employees.Add(newEmployee);
        }

        public void Update(Employee employee)
        {
            _db.Entry(employee).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            _db.Employees.Remove(_db.Employees.Find(id));
        }
    }
}