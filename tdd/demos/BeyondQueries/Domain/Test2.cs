using System;
using System.Linq;
using System.Linq.Expressions;
using BeyondQueries.Models.Data;

namespace BeyondQueries.Domain
{
    public class MovieValidator
    {
        public void DoWork()
        {
            Expression<Func<int, int>> square = x => x*x;
            Func<int, int, int> add = (x, y) => x + y;
            Action<int> write = Console.WriteLine;


            write(square.Compile()(add(3, 5)));

        }   
    }

}