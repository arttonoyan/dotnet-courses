using BenchmarkDotNet.Attributes;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _002_ValueTasks
{
    [MemoryDiagnoser]
    [SimpleJob(launchCount: 1, warmupCount: 1, targetCount: 1)]
    public class MyServiceBenchmarker
    {
        private readonly MyService _service = new();

        [Params(1000, 10000)]
        public int TotalCount { get; set; }

        [Params(1, 10)]
        public int ItemsCount { get; set; }

        [Benchmark]
        public async Task Tasks()
        {
            for (int i = 0; i < TotalCount; i++)
            {
                await _service.GetAsyncTasks(ItemsCount).ToListAsync_Task();
            }
        }

        [Benchmark]
        public async ValueTask ValueTasks()
        {
            for (int i = 0; i < TotalCount; i++)
            {
                await _service.GetAsyncValueTasks(ItemsCount).ToListAsync_ValueTask();
            }
        }
    }
}
