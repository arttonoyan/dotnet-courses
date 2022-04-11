using System;
using System.Threading;

namespace _021_Thread_ManualResetEvent
{
    internal class Program
    {
        // ManualResetEvent - Notifies one or more waiting threads that an event has occurred.
        private static ManualResetEvent manual = new(false);

        static void Main(string[] args)
        {
            Console.WriteLine("Enter any key.\n");

            Thread[] threads = { new Thread(Function1), new Thread(Function2) };

            foreach (Thread thread in threads)
                thread.Start();

            Console.ReadKey();
            manual.Set(); // Sends a signal to all threads.

            // Delay.
            Console.ReadKey();

        }

        static void Function1()
        {
            Console.WriteLine("Task 1 begins and waits for the singnal.");
            manual.WaitOne(); // After WaitOne() completes, the ManualResetEvent remains in the signaled state.
            Console.WriteLine("Task 1 releases.");
        }

        static void Function2()
        {
            Console.WriteLine("Task 2 is running and waits for the singnal.");
            manual.WaitOne(); // After WaitOne() completes, the ManualResetEvent remains in the signaled state.
            Console.WriteLine("Task 2 releases.");
        }

    }
}
