namespace EmployeeTimeCards.Core
{
    public interface IUnitOfWork
    {
        IEmployeeRepository Employees { get; }
        void Commit();
    }
}