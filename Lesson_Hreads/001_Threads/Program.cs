using System;
using System.Threading;

namespace _001_Threads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var thread = new Thread(new ThreadStart(() => ThreadFunc(ConsoleColor.Yellow)));
            var thread1 = new Thread(new ThreadStart(() => ThreadFunc(ConsoleColor.Red)));

            Console.WriteLine("Main thread id: {0} \n", Thread.CurrentThread.GetHashCode());

            thread.Start();
            thread.Join();

            thread1.Start();
            thread1.Join();

            Console.ForegroundColor = ConsoleColor.Green;

            for (int i = 0; i < 160; i++)
            {
                Thread.Sleep(20);
                Console.Write("_");
            }

            Console.ForegroundColor = ConsoleColor.Gray;

            Console.WriteLine("\nMain thread ended.");

            Console.ReadLine();
        }

        private static void ThreadFunc(ConsoleColor color)
        {
            Console.WriteLine("Secondary thread id: {0}", Thread.CurrentThread.ManagedThreadId);
            Console.ForegroundColor = color;

            for (int i = 0; i < 160; i++)
            {
                Thread.Sleep(20);
                Console.Write(".");
            }

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\nSecondary thread ended.");
        }
    }
}
