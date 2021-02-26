using BenchmarkDotNet.Running;

namespace WrappedValuesBenchmarks
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var s2 = BenchmarkRunner.Run<ArraySumBenchmark>();
            // var s1 = BenchmarkRunner.Run<WrappedValuesBenchmark>();
        }

        public const int targetCount = 10;
    }
}