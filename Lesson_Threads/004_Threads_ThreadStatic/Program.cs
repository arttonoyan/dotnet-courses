using System;
using System.Threading;

namespace _004_Threads_ThreadStatic
{
    internal class Program
    {
        //ThreadLocalStorage
        //[ThreadStatic]
        public static int counter;

        static void Main(string[] args)
        {
            var thread = new Thread(Method);
            thread.Start();
            thread.Join();

            Console.WriteLine("Main thread ended...");

            Console.ReadLine();
        }

        public static void Method()
        {
            if (counter < 10)
            {
                counter++;
                Console.WriteLine(counter + " thread id: " + Thread.CurrentThread.GetHashCode());
                var thread = new Thread(Method);
                thread.Start();
                thread.Join();
            }

            Console.WriteLine("Thread {0} end.", Thread.CurrentThread.GetHashCode());
        }
    }
}
