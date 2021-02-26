using System;
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
    public class MathOperationsBenchmark
    {
        [Benchmark(Description = "Sin")]
        public double TestSin()
        {
            return Math.Sin(X);
        }

        [Benchmark(Description = "SinDEG")]
        public double TestSinDeg()
        {
            const double mul = Math.PI / 180;
            return Math.Sin(X * mul);
        }

        [Benchmark(Description = "SinDEG 2")]
        public double TestSinDeg2()
        {
            const double div = 180 / Math.PI;
            return Math.Sin(X / div);
        }

        [Benchmark(Description = "Sqrt")]
        public double TestSqrt()
        {
            return Math.Sqrt(X);
        }
        
        [Benchmark(Description = "Exp")]
        public double TestExp()
        {
            return Math.Exp(X);
        }

        
        [Benchmark(Description = "Log")]
        public double TestLog()
        {
            return Math.Log(X);
        }
        [Benchmark(Description = "Log10")]
        public double TestLog10()
        {
            return Math.Log10(X);
        }

        [Params(0.5)]
        public double X { get; set; }
    }
}