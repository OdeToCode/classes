using System;
using Xunit;

namespace FeatureTests
{

    public class Person
    {
        public string FirstName { get; set; } = null!;
    }

    public class Nullable
    {
        [Fact]
        public void NullableContexts()
        {

            var p = new Person();
            if (p.FirstName != null)
            {
                var l = p.FirstName.Length;
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
