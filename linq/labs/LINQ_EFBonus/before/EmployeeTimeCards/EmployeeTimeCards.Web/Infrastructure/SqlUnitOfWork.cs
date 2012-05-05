using EmployeeTimeCards.Core;

namespace EmployeeTimeCards.Web.Infrastructure
{
    public class SqlUnitOfWork : IUnitOfWork
    {
        private TimeCardContext _db;        

        public SqlUnitOfWork()
        {
            _db = new TimeCardContext();
        }

        public IEmployeeRepository Employees
        {
            get
            {
                return new SqlEmployeeRepository(_db);
            }
        }

        public void Commit()
        {
            _db.SaveChanges();
        }
    }
}