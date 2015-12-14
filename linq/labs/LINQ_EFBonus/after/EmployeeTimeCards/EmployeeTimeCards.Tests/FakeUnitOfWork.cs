using EmployeeTimeCards.Core;

namespace EmployeeTimeCards.Tests
{
    public class FakeUnitOfWork : IUnitOfWork
    {
        public IEmployeeRepository Employees { get; set; }

        public void Commit()
        {
            Committed = true;            
        }

        public bool Committed { get; set; }
    }
}