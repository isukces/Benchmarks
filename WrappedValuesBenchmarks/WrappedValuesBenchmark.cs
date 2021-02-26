using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;

namespace WrappedValuesBenchmarks
{
    [SimpleJob(RunStrategy.ColdStart, targetCount: 15, invocationCount: 300_000_000)]
    public class WrappedValuesBenchmark
    {
        [Benchmark(Description = "Wrapped integer")]
        public XPipeIndex Test1()
        {
            return XPipeIndex.Zero;
        }

        [Benchmark(Description = "Pure integer")]
        public int Test2()
        {
            return 0;
        }
        
        [Benchmark(Description = "Wrapped integer increment")]
        public XPipeIndex Test3()
        {
            var a = XPipeIndex.Zero;
            a++;
            return a;
        }

        [Benchmark(Description = "Pure integer increment")]
        public int Test4()
        {
            var a = 0;
            a++;
            return a;
        }
    }
}