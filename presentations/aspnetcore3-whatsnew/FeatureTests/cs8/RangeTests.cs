using System;
using Xunit;

namespace FeatureTests
{
    public class RangeTests
    {
        [Fact]
        public void Can_Use_Ranges_And_Indices()
        {
            var pets = new[] { "Beaker", "Dash", "Chirp", "Alice", "Tinker", "Skitty" };

            Assert.Equal("Beaker", pets[0]);
            Assert.Equal("Dash", pets[1]);
           
            Assert.Equal("Skitty", pets[^1]);
            Assert.Equal("Tinker", pets[^2]);

            Assert.Equal(new [] { "Dash", "Chirp"}, pets[1..3]);
            Assert.Equal(new[] { "Beaker" }, pets[..1]);
            Assert.Equal(new[] { "Tinker", "Skitty" }, pets[4..]);
            Assert.Equal(new [] { "Tinker", "Skitty"}, pets[^2..^0]);
        }

        [Fact]
        public void Can_Use_Variables()
        {
            Range r = 1..4;
            Index i = ^3;

            var numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            Assert.Equal(8, numbers[i]);
            Assert.Equal(new[] { 2, 3, 4 }, numbers[r]);
        }
    }
}
