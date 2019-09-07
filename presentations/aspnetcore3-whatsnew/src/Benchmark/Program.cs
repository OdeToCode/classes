using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;

namespace Benchmarking
{

    /// <summary>
    /// From Stephen Toub's post: https://devblogs.microsoft.com/dotnet/performance-improvements-in-net-core-3-0/
    /// </summary>

    [MemoryDiagnoser]
    public class Program
    {
        static void Main(string[] args) => BenchmarkSwitcher.FromTypes(new[] { typeof(Program) }).Run(args);

        [Benchmark]
        public int ParseInt32Dec() => int.Parse("12345678");

	    private byte[] _from = new byte[] { 1, 2, 3, 4 };
        private byte[] _to = new byte[4];

        [Benchmark]
        public void CopySpan() => _from.AsSpan().CopyTo(_to);
	
        [Benchmark]
        public bool EqualsIC() => "Some string".Equals("sOME sTrinG", StringComparison.OrdinalIgnoreCase);
    }
}