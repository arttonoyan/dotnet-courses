using System;
using System.Threading.Tasks;

namespace _000_ValueTasks
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            for (int i = 0; i < 1000; i++)
            {
                await RunValueTasks();
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
            return new ValueTask<int>(10);
        }
    }
}
