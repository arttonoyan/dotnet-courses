using System;
using System.Threading;

namespace _009_Threads_Monitor
{
    internal class Program
    {
        private static readonly object _lockObject = new object();

        private static int counter;
        private static readonly Random random = new Random();

        static void Main()
        {
            var reporter = new Thread(Report) { IsBackground = true };
            reporter.Start();

            var threads = new Thread[150];

            for (uint i = 0; i < 150; ++i)
            {
                threads[i] = new Thread(Function);
                threads[i].Start();
            }

            Thread.Sleep(15000);
        }

        // Executes in a separate thread.
        private static void Function()
        {
            try
            {
                Monitor.Enter(_lockObject);
                ++counter;
            }
            finally
            {
                Monitor.Exit(_lockObject);
            }

            int time = random.Next(1000, 12000);
            Thread.Sleep(time);

            try
            {
                Monitor.Enter(_lockObject);
                --counter;
            }
            finally
            {
                Monitor.Exit(_lockObject);
            }
        }

        private static void Report()
        {
            while (true)
            {
                int count;

                try
                {
                    Monitor.Enter(_lockObject);
                    count = counter;
                }
                finally
                {
                    Monitor.Exit(_lockObject);
                }

                Console.WriteLine("{0} Threads active.", counter);
                Thread.Sleep(100);
            }
        }
    }
}
