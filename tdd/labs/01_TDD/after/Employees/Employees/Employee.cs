namespace Employees
{
    public class Employee
    {
        public Employee()
        {
            FirstName = "";
            LastName = "";
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FormatName()
        {
            if(!string.IsNullOrEmpty(LastName) || !string.IsNullOrEmpty(FirstName))
            {
                return LastName + ", " + FirstName;
            }
            return string.Empty;
        }

        public double Salary { get; set; }

        public void GiveRaise(double percentage)
        {
            Salary = Salary * (1+percentage);
        }        
    }
}
