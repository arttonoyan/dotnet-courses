using System;
using System.Threading.Tasks;

namespace _013_Tasks_ValueTask_Exception
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                await ThrowExceptionAsync(test: true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine();
        }

        private static ValueTask ThrowExceptionAsync(bool test)
        {
            try
            {
                if (test)
                    throw new Exception("My Test Exception.");
            }
            catch (Exception ex)
            {
                return new ValueTask(Task.FromException(ex));
            }

            return ValueTask.CompletedTask;
        }
    }
}
