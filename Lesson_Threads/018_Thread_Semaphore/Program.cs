using System;
using System.Threading;

namespace _018_Thread_Semaphore
{
    //https://docs.microsoft.com/en-us/dotnet/api/system.threading.semaphore
    internal class Program
    {
        //Limits the number of threads that can access a resource or pool of resources concurrently.
        // A semaphore that simulates a limited resource pool.
        private static Semaphore _pool;

        static void Main(string[] args)
        {
            // Create a semaphore that can satisfy up to three
            // concurrent requests. Use an initial count of zero,
            // so that the entire semaphore count is initially
            // owned by the main program thread.
            _pool = new Semaphore(1, 5, "MySemaphore");

            for (int i = 1; i <= 15; i++)
            {
                var t = new Thread(Worker);
                t.Start(i);
            }

            // Wait for half a second, to allow all the
            // threads to start and to block on the semaphore.
            Thread.Sleep(4000);

            Console.WriteLine();
            Console.WriteLine("Main thread calls Release(2).");
            _pool.Release(2);

            Console.WriteLine("Main thread exits.");

            Console.ReadLine();
        }

        private static void Worker(object num)
        {
            Console.WriteLine("Thread {0} begins " + "and waits for the semaphore.", num);
            _pool.WaitOne();

            Console.WriteLine("Thread {0} enters the semaphore.", num);
            Thread.Sleep(1000);
            Console.WriteLine("----->Thread {0} releases the semaphore.", num);
            Console.WriteLine();

            _pool.Release();
        }

    }
}
