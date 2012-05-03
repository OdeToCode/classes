using System;

namespace Workplace
{
    public class EmployeeHierarchy : Tree<Employee>
    {
        public EmployeeHierarchy()
        {
            //root
            Data = new Employee
                       {EmployeeID = 1, FirstName = "Jay", LastName = "Adams", HireDate = DateTime.Parse("2007/1/1")};

            //1st level
            Left = new Tree<Employee>();
            Right = new Tree<Employee>();
            Left.Data = new Employee
                            {
                                EmployeeID = 2,
                                FirstName = "Adam",
                                LastName = "Barr",
                                HireDate = DateTime.Parse("2006/3/15")
                            };
            Right.Data = new Employee
                             {
                                 EmployeeID = 17,
                                 FirstName = "Karen",
                                 LastName = "Berge",
                                 HireDate = DateTime.Parse("2005/6/17")
                             };

            //2nd level
            //left
            Left.Left = new Tree<Employee>();
            Left.Right = new Tree<Employee>();
            Left.Left.Data = new Employee
                                 {
                                     EmployeeID = 3,
                                     FirstName = "Scott",
                                     LastName = "Bishop",
                                     HireDate = DateTime.Parse("2000/3/19")
                                 };
            Left.Right.Data = new Employee
                                  {
                                      EmployeeID = 14,
                                      FirstName = "Jo",
                                      LastName = "Brown",
                                      HireDate = DateTime.Parse("2003/7/17")
                                  };

            //right
            Right.Left = new Tree<Employee>();
            Right.Right = new Tree<Employee>();
            Right.Left.Data = new Employee
                                  {
                                      EmployeeID = 18,
                                      FirstName = "David",
                                      LastName = "Campbell",
                                      HireDate = DateTime.Parse("2005/9/13")
                                  };
            Right.Right.Data = new Employee
                                   {
                                       EmployeeID = 19,
                                       FirstName = "Rob",
                                       LastName = "Caron",
                                       HireDate = DateTime.Parse("2002/12/3")
                                   };

            //3rd level
            //left
            //left.left
            Left.Left.Left = new Tree<Employee>();
            Left.Left.Right = new Tree<Employee>();
            Left.Left.Left.Data = new Employee
                                      {
                                          EmployeeID = 4,
                                          FirstName = "Jane",
                                          LastName = "Clayton",
                                          HireDate = DateTime.Parse("2008/7/1")
                                      };
            Left.Left.Right.Data = new Employee
                                       {
                                           EmployeeID = 7,
                                           FirstName = "Pat",
                                           LastName = "Coleman",
                                           HireDate = DateTime.Parse("2008/1/7")
                                       };
            //left.right
            Left.Right.Left = new Tree<Employee>();
            Left.Right.Right = new Tree<Employee>();
            Left.Right.Left.Data = new Employee
                                       {
                                           EmployeeID = 15,
                                           FirstName = "Aaron",
                                           LastName = "Con",
                                           HireDate = DateTime.Parse("2001/11/1")
                                       };
            Left.Right.Right.Data = new Employee
                                        {
                                            EmployeeID = 16,
                                            FirstName = "Don",
                                            LastName = "Hall",
                                            HireDate = DateTime.Parse("2006/4/21")
                                        };

            //4th level
            //left.left.left
            Left.Left.Left.Left = new Tree<Employee>();
            Left.Left.Left.Right = new Tree<Employee>();
            Left.Left.Left.Left.Data = new Employee
                                           {
                                               EmployeeID = 5,
                                               FirstName = "Joe",
                                               LastName = "Howard",
                                               HireDate = DateTime.Parse("2006/7/19")
                                           };
            Left.Left.Left.Right.Data = new Employee
                                            {
                                                EmployeeID = 6,
                                                FirstName = "Jim",
                                                LastName = "Kim",
                                                HireDate = DateTime.Parse("2001/3/9")
                                            };
            //left.left.right
            Left.Left.Right.Left = new Tree<Employee>();
            Left.Left.Right.Right = new Tree<Employee>();
            Left.Left.Right.Left.Data = new Employee
                                            {
                                                EmployeeID = 8,
                                                FirstName = "Eric",
                                                LastName = "Lang",
                                                HireDate = DateTime.Parse("2005/7/15")
                                            };
            Left.Left.Right.Right.Data = new Employee
                                             {
                                                 EmployeeID = 11,
                                                 FirstName = "Jose",
                                                 LastName = "Lugo",
                                                 HireDate = DateTime.Parse("2003/8/6")
                                             };

            Left.Left.Right.Left.Left = new Tree<Employee>();
            Left.Left.Right.Left.Right = new Tree<Employee>();
            Left.Left.Right.Left.Left.Data = new Employee
                                                 {
                                                     EmployeeID = 9,
                                                     FirstName = "Nikki",
                                                     LastName = "McCormick",
                                                     HireDate = DateTime.Parse("2005/5/18")
                                                 };
            Left.Left.Right.Left.Right.Data = new Employee
                                                  {
                                                      EmployeeID = 10,
                                                      FirstName = "Susan",
                                                      LastName = "Metters",
                                                      HireDate = DateTime.Parse("2002/8/5")
                                                  };
            Left.Left.Right.Right.Left = new Tree<Employee>();
            Left.Left.Right.Right.Right = new Tree<Employee>();
            Left.Left.Right.Right.Left.Data = new Employee
                                                  {
                                                      EmployeeID = 12,
                                                      FirstName = "Linda",
                                                      LastName = "MIctchell",
                                                      HireDate = DateTime.Parse("2006/10/1")
                                                  };
            Left.Left.Right.Right.Right.Data = new Employee
                                                   {
                                                       EmployeeID = 13,
                                                       FirstName = "Kim",
                                                       LastName = "Ralls",
                                                       HireDate = DateTime.Parse("2002/12/7")
                                                   };
        }
    }
}