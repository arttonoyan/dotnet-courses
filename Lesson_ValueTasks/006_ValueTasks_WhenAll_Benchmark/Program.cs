using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Linq;
using System.Threading.Tasks;

namespace _006_ValueTasks_WhenAll_Benchmark
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<ReaderBenchmarker>();
        }
    }

    [MemoryDiagnoser]
    [SimpleJob(launchCount: 3, warmupCount: 2, targetCount: 2)]
    public class ReaderBenchmarker
    {
        [Params(100, 1000)]
        public int Count { get; set; }

        [Benchmark]
        public async Task Tasks()
        {
            await Task.WhenAll(
                Enumerable.Range(1, Count)
                    .Select(id => Task.Run(() => ReturnTask(id))));
        }

        [Benchmark]
        public async Task ValueTasks_Await()
        {
            await Task.WhenAll(
                Enumerable.Range(1, Count)
                    .Select(id => Task.Run(async () => await ReturnValueTask(id))));
        }

        [Benchmark]
        public async Task ValueTasks_AsTask()
        {
            await Task.WhenAll(
                Enumerable.Range(1, Count)
                    .Select(id => Task.Run(() => ReturnValueTask(id).AsTask())));
        }

        private static ValueTask<int> ReturnValueTask(int id) => ValueTask.FromResult(id);

        private static Task<int> ReturnTask(int id) => Task.FromResult(id);
    }
}
