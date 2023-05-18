using System.Collections.Generic;
using System.Threading.Tasks;

namespace _002_ValueTasks
{
    public class MyService
    {
        public async IAsyncEnumerable<int> GetAsyncTasks(int count)
        {
            for (int i = 0; i < count; i++)
            {
                yield return await RunTask(i);
            }
        }

        public async IAsyncEnumerable<int> GetAsyncValueTasks(int count)
        {
            for (int i = 0; i < count; i++)
            {
                yield return await RunValueTask(i);
            }
        }

        private Task<int> RunTask(int value)
        {
            return Task.FromResult(value);
        }

        private ValueTask<int> RunValueTask(int value)
        {
            return ValueTask.FromResult(value);
        }
    }
}
