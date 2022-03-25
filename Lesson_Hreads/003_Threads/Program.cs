using System;
using System.Threading;

namespace _003_Threads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main thread id: {0}", Thread.CurrentThread.ManagedThreadId);

            var thread = new Thread(() => Method1("."));
            thread.Start();
            thread.Join();

            Console.ReadLine();
        }

        private static void Method1(string symbol)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Method1 thread id: {0}", Thread.CurrentThread.ManagedThreadId);

            for (int i = 0; i < 128; i++)
            {
                Thread.Sleep(20);
                Console.Write(symbol);
            }

            var thread = new Thread(() => Method2("-"));
            thread.Start();
            thread.Join();
        }

        private static void Method2(string symbol)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Method2 thread id: {0}", Thread.CurrentThread.ManagedThreadId);


            for (int i = 0; i < 128; i++)
            {
                Thread.Sleep(20);
                Console.Write(symbol);
            }

            var thread = new Thread(() => Method3("$"));
            thread.Start();
            thread.Join();
        }

        private static void Method3(string symbol)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Method3 thread id: {0}", Thread.CurrentThread.ManagedThreadId);

            for (int i = 0; i < 128; i++)
            {
                Thread.Sleep(20);
                Console.Write(symbol);
            }
        }
    }
}
