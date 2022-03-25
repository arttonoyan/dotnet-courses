using System;
using System.Threading;

namespace _002_Threads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var thread1 = new Thread(() => ThreadFunc("."));
            var thread2 = new Thread(() => ThreadFunc("$"));
            var thread3 = new Thread(() => ThreadFunc("-"));

            thread1.Start();
            thread2.Start();
            thread3.Start();

            Console.ReadLine();
        }

        private static void ThreadFunc(string symbol)
        {
            Console.WriteLine("Secondary thread id: {0}", Thread.CurrentThread.ManagedThreadId);

            Struct_512KB a512;

            for (int i = 0; i < 128; i++)
            {
                Thread.Sleep(20);
                Console.Write(symbol);
            }
        }
    }
}
