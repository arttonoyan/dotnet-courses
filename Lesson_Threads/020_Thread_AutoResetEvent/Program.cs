using System;
using System.Threading;

namespace _020_Thread_AutoResetEvent
{
    internal class Program
    {
        // Represents a thread synchronization event that, when signaled, resets automatically 
        //after releasing a single waiting thread. This class cannot be inherited.
        static readonly AutoResetEvent auto = new(false);

        static void Main(string[] args)
        {
            Console.WriteLine("Enter any key.\n");

            var thread = new Thread(Function);
            thread.Start();

            Console.ReadKey();
            auto.Set(); // Send a signal to the first thread

            Console.ReadKey();
            auto.Set(); // Send a signal to the first thread

            // Delay.
            Console.ReadKey();
        }

        static void Function()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Red light");
            Console.ResetColor();

            auto.WaitOne(); // After WaitOne() completes, the AutoResetEvent automatically transitions to the non-signaled state.
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Yellow");
            Console.ResetColor();

            auto.WaitOne(); // After WaitOne() completes, the AutoResetEvent automatically transitions to the non-signaled state.
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Green");
            Console.ResetColor();
        }

    }
}
