using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace FeatureTests
{

    public class Sequences
    {
        public async IAsyncEnumerable<int> Generate()
        {
            yield return 3;
            await Task.Delay(10);
            yield return 5;
            for(var i = 10; i < 15; i++)
            {
                await Task.Delay(10);
                yield return i;
            }
            yield return 2;
        }
    }

    public class AsyncStreamTests
    {
        [Fact]
        public async Task Can_Process_Stream_Async()
        {
            var sequences = new Sequences();
            var sum = 0;

            await foreach(var number in sequences.Generate())
            {
                sum += number;
            }

            Assert.Equal(70, sum);
        }
    }
}
