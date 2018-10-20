using System;
using lib01;

namespace lab01
{
    class Program
    {
        static void Main(string[] args)
        {
            var directory = new Class1().GetBaseDirectory();
            Console.WriteLine(directory);
        }
    }
}
