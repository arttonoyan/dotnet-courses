using System;
using System.Threading;
using System.Threading.Tasks;

namespace _002_Tasks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Main Thread start.");

            var task1 = new Task(Worker);
            var task2 = new Task(Worker);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("task1 Id: " + task1.Id);
            Console.WriteLine("task2 Id: " + task2.Id);
            Console.ResetColor();

            task1.Start();
            task2.Start();

            for (int i = 0; i < 60; i++)
            {
                Console.Write(".");
                Thread.Sleep(100);
            }

            Console.WriteLine();
            Console.WriteLine("Main thread has been completed. CurrentId = null? - {0}.", Task.CurrentId == null);

            Console.ReadLine();
        }

        static void Worker()
        {
            Console.WriteLine("Worker() # " + Task.CurrentId + " Start.");

            for (int count = 0; count < 10; count++)
            {
                Thread.Sleep(500);

                Console.WriteLine("Worker() #" + Task.CurrentId + " count: " + count);
            }

            Console.WriteLine("Worker() # " + Task.CurrentId + " End.");
        }

    }
}
