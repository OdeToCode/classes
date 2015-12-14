using System;

namespace csharp_4
{
    public class Animal {}

    public class Person : Animal
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public void SayName()
        {
            Console.WriteLine(Name);
        }
    }
}