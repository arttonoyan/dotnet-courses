using System;
using System.Threading;
using System.Threading.Tasks;

namespace _010_Tasks_Timer
{
    internal class Program
    {
        private static Timer timer;

        static async Task Main(string[] args)
        {
            Console.WriteLine("Checking status every 2 seconds.");

            //await StatusWithDelay();
            //timer = new Timer(Status, null, Timeout.Infinite, Timeout.Infinite);
            timer = new Timer(Status, null, 0, 1000);
            //timer.Change(0, Timeout.Infinite);

            Console.ReadLine();
        }

        private static void Status(object state)
        {
            Console.WriteLine($"Status for thread: {Thread.CurrentThread.ManagedThreadId} at: {DateTime.Now}");
            Thread.Sleep(4000); // work simulation

            // Console.ForegroundColor = ConsoleColor.Red;
            // Console.WriteLine($"After the work is done: {Thread.CurrentThread.ManagedThreadId} at: {DateTime.Now}");
            // Console.ResetColor();
            //timer.Change(2000, Timeout.Infinite);
        }

        private static async Task StatusWithDelay()
        {
            while (true)
            {
                Console.WriteLine($"Status for thread: {Thread.CurrentThread.ManagedThreadId} at: {DateTime.Now}");
                await Task.Delay(2000); // work simulation
            }
        }
    }
}
