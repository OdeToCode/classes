using System;
using Xunit;

namespace FeatureTests
{

    public class SomethingDisposable : IDisposable
    {
        public bool Disposed { get; private set; } = false;

        public void Dispose()
        {
            Disposed = true;
        }
    }

    public class UsingDeclarationTests
    {
        [Fact]
        public void Can_Dispose()
        {
            SomethingDisposable disposable;
            {
                using var thing = new SomethingDisposable();
                disposable = thing;
                Assert.False(disposable.Disposed);
            }
            Assert.True(disposable.Disposed);
        }
    }
}
