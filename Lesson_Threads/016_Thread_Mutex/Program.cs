using System;
using System.Threading;

namespace _016_Thread_Mutex
{
    //https://docs.microsoft.com/en-us/dotnet/api/system.threading.mutex
    internal class Program
    {
        //A synchronization primitive that can also be used for interprocess synchronization.
        private static Mutex mutex = new();
        private const int numIterations = 1;
        private const int numThreads = 5;

        static void Main(string[] args)
        {
            // Create the threads that will use the protected resource.
            for (int i = 0; i < numThreads; i++)
            {
                var thread = new Thread(ThreadProc)
                {
                    Name = $"Thread{i + 1}"
                };
                thread.Start();
            }

            // The main thread exits, but the application continues to
            // run until all foreground threads have exited.
            Console.ReadLine();
        }

        private static void ThreadProc()
        {
            for (int i = 0; i < numIterations; i++)
            {
                UseResource();
            }
        }

        // This method represents a resource that must be synchronized
        // so that only one thread at a time can enter.
        private static void UseResource()
        {
            // Wait until it is safe to enter.
            mutex.WaitOne();

            Console.WriteLine("{0} has entered the protected area", Thread.CurrentThread.Name);

            // Place code to access non-reentrant resources here.

            // Simulate some work.
            Thread.Sleep(1000);

            Console.WriteLine("{0} is leaving the protected area", Thread.CurrentThread.Name);
            Console.WriteLine();

            // Release the Mutex.
            mutex.ReleaseMutex();
        }

    }
}
