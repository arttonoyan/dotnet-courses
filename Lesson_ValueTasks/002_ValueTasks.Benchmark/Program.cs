using BenchmarkDotNet.Running;
using System;

namespace _002_ValueTasks.Benchmark
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<MyServiceBenchmarker>();
        }
    }
}
