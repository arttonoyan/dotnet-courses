using System;
using System.Threading;

namespace _006_Threads_Background
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var t = new Thread(Worker);

            // Turning a thread into a background thread
            t.IsBackground = false;
            t.Start();

            //Thread.Sleep(2000);
            Console.WriteLine("Returning from Main");
        }

        private static void Worker()
        {
            Thread.Sleep(100);
            Console.ForegroundColor = ConsoleColor.Yellow;

            //10 Second
            //Thread.Sleep(10000);
            for (int i = 0; i < 160; i++)
            {
                Thread.Sleep(20);
                Console.Write(".");
            }

            Console.WriteLine();
            Console.WriteLine("Returning from Worker");
        }
    }
}
