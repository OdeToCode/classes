using System;
using System.Collections.Generic;

namespace Workplace
{
    public class EmployeeList : List<Employee>
    {
        public EmployeeList()
        {
            Add(new Employee { EmployeeID = 1, FirstName = "Jay", LastName = "Adams", HireDate = DateTime.Parse("2007/1/1") });
            Add(new Employee { EmployeeID = 2, FirstName = "Adam", LastName = "Barr", HireDate = DateTime.Parse("2006/3/15") });
            Add(new Employee { EmployeeID = 3, FirstName = "Karen", LastName = "Berge", HireDate = DateTime.Parse("2005/6/17") });
            Add(new Employee { EmployeeID = 4, FirstName = "Scott", LastName = "Bishop", HireDate = DateTime.Parse("2000/3/19") });
            Add(new Employee { EmployeeID = 5, FirstName = "Jo", LastName = "Brown", HireDate = DateTime.Parse("2003/7/17") });
            Add(new Employee { EmployeeID = 6, FirstName = "David", LastName = "Campbell", HireDate = DateTime.Parse("2005/9/13") });
            Add(new Employee { EmployeeID = 7, FirstName = "Rob", LastName = "Caron", HireDate = DateTime.Parse("2002/12/3") });
            Add(new Employee { EmployeeID = 8, FirstName = "Jane", LastName = "Clayton", HireDate = DateTime.Parse("2008/7/1") });
            Add(new Employee { EmployeeID = 9, FirstName = "Pat", LastName = "Coleman", HireDate = DateTime.Parse("2008/1/7") });
            Add(new Employee { EmployeeID = 10, FirstName = "Aaron", LastName = "Con", HireDate = DateTime.Parse("2001/11/1") });
            Add(new Employee { EmployeeID = 11, FirstName = "Don", LastName = "Hall", HireDate = DateTime.Parse("2006/4/21") });
            Add(new Employee { EmployeeID = 12, FirstName = "Joe", LastName = "Howard", HireDate = DateTime.Parse("2006/7/19") });
            Add(new Employee { EmployeeID = 13, FirstName = "Jim", LastName = "Kim", HireDate = DateTime.Parse("2001/3/9") });
            Add(new Employee { EmployeeID = 14, FirstName = "Eric", LastName = "Lang", HireDate = DateTime.Parse("2005/7/15") });
            Add(new Employee { EmployeeID = 15, FirstName = "Jose", LastName = "Lugo", HireDate = DateTime.Parse("2003/8/6") });
            Add(new Employee { EmployeeID = 16, FirstName = "Nikki", LastName = "McCormick", HireDate = DateTime.Parse("2005/5/18") });
            Add(new Employee { EmployeeID = 17, FirstName = "Susan", LastName = "Metters", HireDate = DateTime.Parse("2002/8/5") });
            Add(new Employee { EmployeeID = 18, FirstName = "Linda", LastName = "MIctchell", HireDate = DateTime.Parse("2006/10/1") });
            Add(new Employee { EmployeeID = 19, FirstName = "Kim", LastName = "Ralls", HireDate = DateTime.Parse("2002/12/7") });
            Add(new Employee { EmployeeID = 20, FirstName = "Jeff", LastName = "Smith", HireDate = DateTime.Parse("2001/3/30") });
        } 
    }
}