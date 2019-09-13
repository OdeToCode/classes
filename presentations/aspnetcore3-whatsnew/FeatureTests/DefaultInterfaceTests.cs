using Xunit;

namespace FeatureTests
{
    public interface ICalculator
    {
        int Add(int x, int y);
        int Multiply(int x, int y)
        {
            return x * y;
        }
    }

    public class Calculator : ICalculator
    {
        public int Add(int x, int y)
        {
            return x + y;
        }
    }

    public class DefaultInterfaceTests
    {
        [Fact]
        public void Interface_Has_Default_Implementation()
        {
            ICalculator calculator = new Calculator();
            var result = calculator.Multiply(5, 3);
            Assert.Equal(15, result);
        }
    }
}
