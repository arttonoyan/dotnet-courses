using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Threading.Tasks;

namespace _001_ValueTasks.Benchmark
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<TasksBenchmarker>();
        }
    }

    [MemoryDiagnoser]
    [SimpleJob(launchCount: 1, warmupCount: 1, targetCount: 1)]
    public class TasksBenchmarker
    {
        [Params(1000, 10000)]
        public int TotalCount { get; set; }

        [Benchmark]
        public async Task Tasks()
        {
            for (int i = 0; i < TotalCount; i++)
            {
                await RunTask();
            }
        }

        [Benchmark]
        public async Task ValueTasks()
        {
            for (int i = 0; i < TotalCount; i++)
            {
                await RunValueTask();
            }
        }

        private Task<int> RunTask()
        {
            return Task.FromResult(10);
        }

        private ValueTask<int> RunValueTask()
        {
            return new ValueTask<int>(10);
        }
    }
}
