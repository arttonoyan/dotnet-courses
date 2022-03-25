using System;
using System.Threading;

namespace _010_Threads_LockBoxing
{
    internal class Program
    {
        private static int counter = 0;

        static void Main()
        {
            var thread1 = new Thread(Worker);
            thread1.Start();

            var thread2 = new Thread(Worker);
            thread2.Start();

            var thread3 = new Thread(Worker);
            thread3.Start();

            Console.ReadLine();
        }

        private static int block = 0;

        static private void Worker()
        {
            for (int i = 0; i < 50; ++i)
            {
                Monitor.Enter((object)block);
                try
                {
                    Console.WriteLine(++counter);
                }
                finally
                {
                    Monitor.Exit((object)block);
                }
            }
        }
    }
}
