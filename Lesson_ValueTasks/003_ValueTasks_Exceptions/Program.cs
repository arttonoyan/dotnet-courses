using System;
using System.Threading.Tasks;

namespace _003_ValueTasks_Exceptions
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
                //...

                if (test)
                    throw new Exception("My Test Exception.");

                //...

                return ValueTask.CompletedTask;
            }
            catch (Exception ex)
            {
                return new ValueTask(Task.FromException(ex));
            }
        }
    }
}
