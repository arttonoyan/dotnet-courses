using System;
using System.Threading;
using System.Threading.Tasks;

namespace _006_Tasks_ContinueWith
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var taskA = new Task(() =>
            {
                Console.WriteLine("Hello from taskA.");
                Console.ForegroundColor = ConsoleColor.Yellow;
                for (int count = 0; count < 50; count++)
                {
                    Thread.Sleep(100);
                    Console.Write("-");
                }
                Console.ResetColor();
                Console.WriteLine();
            });

            var taskb = taskA.ContinueWith(t =>
            {
                Console.WriteLine("Hello from taskB.");
                Console.ForegroundColor = ConsoleColor.Green;
                for (int count = 0; count < 50; count++)
                {
                    Thread.Sleep(100);
                    Console.Write("^");
                }

                Console.ResetColor();
                Console.WriteLine();
            });

            taskA.Start();
            taskb.Wait();

            Console.WriteLine("Main thread has been completed.");

            Console.ReadLine();
        }
    }
}
