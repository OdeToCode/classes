using System;
using Xunit;

namespace FeatureTests
{

    public class Person
    {
        public Person()
        {
            FirstName = "";
        }

        public string FirstName { get; set; }
        public string? LastName { get; set; }
    }

    public class Nullable
    {
        [Fact]
        public void NullableContexts()
        {
            var p = new Person();
            if (p.LastName == null)
            {

            }
            else
            {
                Assert.Equal(5, p.LastName.Length);
            }
            
           

#nullable enable
            string x = null;
            Console.WriteLine(x);

#nullable disable
            string y = null;
            Console.WriteLine(y);

#nullable enable
            string z = null!;
            Console.WriteLine(z);

        }
    }
}
