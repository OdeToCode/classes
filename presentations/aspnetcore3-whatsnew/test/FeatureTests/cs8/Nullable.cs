using System;
using Xunit;

namespace FeatureTests
{    
    public class Nullable
    {
        [Fact]
        public void NullableContexts()
        {

#nullable enable
            string? x = null;
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
