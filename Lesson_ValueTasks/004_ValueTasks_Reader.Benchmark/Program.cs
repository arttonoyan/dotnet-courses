using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.IO;
using System.Threading.Tasks;

namespace _004_ValueTasks_Reader.Benchmark
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<ReaderBenchmarker>();
        }
    }

    [MemoryDiagnoser]
    [SimpleJob(launchCount: 1, warmupCount: 1, targetCount: 1)]
    public class ReaderBenchmarker
    {
        [Benchmark]
        public async Task<long> Tasks()
        {
            using var reader = new ByteReader(new FileStream("004_ValueTasks_Reader.Benchmark.exe", FileMode.Open, FileAccess.Read));
            long sum = 0;
            while (true)
            {
                var b = await reader.GetNextByteAsync_Task();
                if (b == -1)
                    break;

                sum += b;
            }

            return sum;
        }

        [Benchmark]
        public async ValueTask<long> ValueTasks()
        {
            using var reader = new ByteReader(new FileStream("004_ValueTasks_Reader.Benchmark.exe", FileMode.Open, FileAccess.Read));
            long sum = 0;
            while (true)
            {
                var b = await reader.GetNextByteAsync();
                if (b == -1)
                    break;

                sum += b;
            }

            return sum;
        }
    }
}
