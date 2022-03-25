using System;
using System.Threading;

namespace _007_Threads_Interlocked
{
    internal class Program
    {
        private static long counter;
        private static readonly Random random = new Random();

        static void Main()
        {
            var reporter = new Thread(Report) { IsBackground = true };
            reporter.Start();

            var threads = new Thread[150];

            for (uint i = 0; i < 150; ++i)
            {
                threads[i] = new Thread(Worker);
                threads[i].Start();
            }

            Thread.Sleep(15000);

            Console.ReadLine();
        }

        private static void Worker()
        {
            //Interlocked.Increment(ref counter);

            counter++;
            try
            {
                // The thread waits for a random period of time from 1 to 12 seconds.
                int time = random.Next(1, 12);
                Thread.Sleep(time);
            }
            finally
            {
                //Interlocked.Decrement(ref counter);
                counter--;
            }
        }

        private static void Report()
        {
            while (true)
            {
                long number = Interlocked.Read(ref counter);

                Console.WriteLine("{0} Threads active.", number);
                Thread.Sleep(100);
            }
        }
    }
}
