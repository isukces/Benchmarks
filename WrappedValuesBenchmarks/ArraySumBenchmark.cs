using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Mathematics;

namespace WrappedValuesBenchmarks
{
    [MarkdownExporterAttribute.GitHub]
    [HtmlExporter]
    [RPlotExporter]
    [SimpleJob(RuntimeMoniker.Net472, targetCount: Program.targetCount,
        id: "Net472")]
    [SimpleJob(RuntimeMoniker.Net48, targetCount: Program.targetCount,
        id: "Net48")]
    [SimpleJob(RuntimeMoniker.NetCoreApp31, targetCount: Program.targetCount,
        id: "CoreApp31")]
    [SimpleJob(RuntimeMoniker.NetCoreApp50, targetCount: Program.targetCount,
        id: "CoreApp50")]
    [RankColumn(NumeralSystem.Stars)]
    public class ArraySumBenchmark
    {
        static ArraySumBenchmark()
        {
            Data1 = new[] {1, 4, 6, 3, 5, 67, 88, 77, 11, 3, 324, 532};
            Data2 = new RandomAddList<XPipeIndex, int>();
            Data3 = new Dictionary<XPipeIndex, int>();
            Data4 = new Dictionary<int, int>();
            for (var index = 0; index < Data1.Length; index++)
            {
                var value = Data1[index];
                Data2[new XPipeIndex(index)] = value;
                Data3[new XPipeIndex(index)] = value;
                Data4[index]                 = value;
            }
        }

        [Benchmark(Description = "Wrap[]")]
        public int Test1()
        {
            var sum = 0;
            for (var i = 0; i < Data1.Length; i++)
            {
                var t = new XPipeIndex(i);
                sum += Data1[t.Value];
            }

            return sum;
        }

        [Benchmark(Description = "Int[]", Baseline = true)]
        public int Test1A()
        {
            var sum = 0;
            var src = Data1;
            for (var i = 0; i < src.Length; i++)
                sum += src[i];

            return sum;
        }


        [Benchmark(Description = "Wrap[+]")]
        public int Test2()
        {
            var sum = 0;
            var src = Data2;
            for (var i = 0; i < src.Count; i++)
            {
                var t = new XPipeIndex(i);
                sum += src[new XPipeIndex(t.Value)];
            }

            return sum;
        }


        [Benchmark(Description = "Wrap Dict")]
        public int Test3()
        {
            var sum = 0;
            var src = Data3;
            for (var i = 0; i < src.Count; i++)
            {
                var t = new XPipeIndex(i);
                sum += src[new XPipeIndex(t.Value)];
            }

            return sum;
        }

        [Benchmark(Description = "Int Dict")]
        public int Test4()
        {
            var sum                                 = 0;
            var src                                 = Data4;
            for (var i = 0; i < src.Count; i++) sum += src[i];

            return sum;
        }

        [Benchmark(Description = "Linq")]
        public int Test5()
        {
            return Data1.Sum();
        }

        [Benchmark(Description = "Linq @")]
        public int Test6()
        {
            return Data2.AsX().Sum();
        }

        [Benchmark(Description = "Linq Dict")]
        public int Test7()
        {
            return Data4.Values.Sum();
        }

        private static readonly int[] Data1;
        private static readonly RandomAddList<XPipeIndex, int> Data2;
        private static readonly Dictionary<XPipeIndex, int> Data3;
        private static readonly Dictionary<int, int> Data4;
    }
}