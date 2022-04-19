using System;
using System.Threading;
using System.Threading.Tasks;

namespace _007_Tasks_Cancellation
{
    //https://docs.microsoft.com/en-us/dotnet/standard/threading/cancellation-in-managed-threads
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting Main Thread.");

            // Create an object of the source of cancellation flags.
            var cancelTokSrc = new CancellationTokenSource();

            // Start the task, passing the cancel flag to itself and the delegate.
            var task = Task.Factory.StartNew(MyTask, cancelTokSrc.Token, cancelTokSrc.Token);

            // Allow the task to run until it is cancelled.
            Thread.Sleep(2000);

            try
            {
                // Cancel the task.
                cancelTokSrc.Cancel();
                Console.WriteLine("Cancellation set in token source...");

                // Suspend the execution of the Main() method until the task is completed - task.
                task.Wait();
            }
            catch (AggregateException e)
            {
                if (task.IsCanceled)
                    Console.WriteLine("\nThe wait operation was canceled.\n");

                // Uncomment to view the exception.
                Console.WriteLine("- " + e.InnerException.Message);
            }
            finally
            {
                task.Dispose();
                cancelTokSrc.Dispose();
            }

            Console.WriteLine("Finish.");

            // Delay.
            Console.ReadLine();
        }

        static void MyTask(object ct)
        {
            var cancelTok = (CancellationToken)ct;

            // Check if the task has been canceled before running it.
            cancelTok.ThrowIfCancellationRequested();

            Console.WriteLine("Starting MyTask().");

            for (int count = 0; count < 10; count++)
            {
                // Polling is used to track task cancellation.
                if (cancelTok.IsCancellationRequested)
                {
                    Console.WriteLine("Cancelling at task.");
                    cancelTok.ThrowIfCancellationRequested();
                }

                Thread.Sleep(500);
                Console.WriteLine("MyTask(), counter: " + count);
            }

            Console.WriteLine("MyTask() completed.");
        }

    }
}
