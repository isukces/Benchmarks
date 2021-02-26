using System;
using BenchmarkDotNet.Running;

namespace WrappedValuesBenchmarks
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<WrappedValuesBenchmark>();
        }
    }
}