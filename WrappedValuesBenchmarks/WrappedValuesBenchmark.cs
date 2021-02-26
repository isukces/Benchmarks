using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Mathematics;

namespace WrappedValuesBenchmarks
{
    [MarkdownExporterAttribute.GitHub]
    [HtmlExporter]
    //[SimpleJob(RuntimeMoniker.Mono, targetCount: Program.targetCount, invocationCount: 210_000_000, id: "Mono1")]
    //[SimpleJob(RuntimeMoniker.Net48, targetCount: Program.targetCount, invocationCount: 210_000_000, id: "Net 48")]
    //[SimpleJob(RuntimeMoniker.NetCoreApp31, targetCount: Program.targetCount, invocationCount: 210_000_000, id: "Net 48")]
    [SimpleJob(RuntimeMoniker.NetCoreApp50, targetCount: Program.targetCount,
        //invocationCount: 210_000_000,
        id: "CoreApp50")]
    [SimpleJob(RuntimeMoniker.Net472, targetCount: Program.targetCount,
        //invocationCount: 210_000_000,
        id: "Net472")]
    //[LegacyJitX86Job]
    //[LegacyJitX64Job]
    // [RyuJitX64Job]
    [RankColumn(NumeralSystem.Stars)]
    public class WrappedValuesBenchmark
    {
        [Benchmark(Description = "Wrapped integer", Baseline = true)]
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