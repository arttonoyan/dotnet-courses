using BenchmarkDotNet.Running;
using System;

namespace _006_StringBuilder_Benchmark
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<StringBenchmarker>();
        }
    }
}
