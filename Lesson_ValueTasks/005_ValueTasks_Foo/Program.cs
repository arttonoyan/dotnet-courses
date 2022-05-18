using System;
using System.Threading.Tasks;

namespace _005_ValueTasks_Foo
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            // Task<TResult> Task.Run<TResult>(Func<TResult> action) where TResult is ValueTask
            ValueTask<int> value = await Task.Run(() => ReturnValueTask());

            // So, we need to await the ValueTask<int>
            var valueTaskResult = await value;

            Console.ReadLine();
        }
        #region Tasks

        static async Task<int> AwaitTask()
        {
            return await RunTask();
        }

        static Task<int> RunTask()
        {
            return Task.Run(() => ReturnTask());
        }

        static Task<int> ReturnTask() => Task.FromResult(42);

        #endregion


        #region ValueTasks

        static async ValueTask<int> AwaitValueTask()
        {
            var value = await RunValueTask();
            var result = await value;
            return result;
        }

        static async ValueTask<int> AwaitValueTask_2()
        {
            return await await RunValueTask();
        }

        static Task<ValueTask<int>> RunValueTask()
        {
            return Task.Run(() => ReturnValueTask());
        }

        static ValueTask<int> ReturnValueTask() => new(42);

        #endregion
    }
}
