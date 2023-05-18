using System;
using System.Threading.Tasks;

namespace _001_ValueTasks
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                int value = await RunValueTasks();
                Console.WriteLine(value);
            }

            Console.WriteLine("Finish");

            Console.ReadLine();
        }

        private static Task<int> RunTasks()
        {
            return Task.FromResult(10);
        }

        private static ValueTask<int> RunValueTasks()
        {
            return ValueTask.FromResult(10);
        }
    }
}
