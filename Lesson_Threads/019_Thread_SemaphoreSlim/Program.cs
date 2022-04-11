using System;
using System.Threading;

namespace _019_Thread_SemaphoreSlim
{
    internal class Program
    {
        private static SemaphoreSlim _pool;

        static void Main(string[] args)
        {
            _pool = new SemaphoreSlim(1, 3);

            for (int i = 1; i <= 5; i++)
            {
                var t = new Thread(Worker);
                t.Start(i);
            }

            // Wait for half a second, to allow all the
            // threads to start and to block on the semaphore.
            Thread.Sleep(2000);

            Console.WriteLine();
            Console.WriteLine("Main thread calls Release(2).");
            _pool.Release(2);

            Console.WriteLine("Main thread exits.");
            Console.ReadLine();
        }

        private static void Worker(object num)
        {
            Console.WriteLine("Thread {0} begins " + "and waits for the semaphore.", num);
            _pool.Wait();

            Console.WriteLine("Thread {0} enters the semaphore.", num);
            Thread.Sleep(1000);
            Console.WriteLine("----->Thread {0} releases the semaphore.", num);

            _pool.Release();
        }

    }
}
