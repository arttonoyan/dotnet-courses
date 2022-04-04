using System;
using System.Threading;

namespace _013_Thread_Volatile
{
    //https://www.youtube.com/watch?v=DAwhCr3tS-8
    //https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/volatile
    internal class Program
    {
        //static volatile bool stop; // No JIT optimizations.
        static bool stop; // With JIT optimization.

        static void Main(string[] args)
        {
            Console.WriteLine("Main: run thread in 2 second");
            var thread = new Thread(Worker);
            thread.Start();

            Thread.Sleep(2000);

            stop = true;
            Console.WriteLine("Main: waiting for the thread to complete.");
            thread.Join();

            Console.ReadLine();
        }

        private static void Worker(object o)
        {
            int x = 0;
            while (!stop)
            {
                x++;
            }

            //// Code after JIT optimization if stop is not volatile:
            //// If the stop is volatile, then JIT optimization by the compiler will not be performed.
            //int x = 0;
            //if (stop != true)
            //{
            //    while (true)
            //    {
            //        x++;
            //    }
            //}

            Console.WriteLine("Worker: x = {0}.", x);
        }

    }
}
