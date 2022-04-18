using System;
using System.Threading;
using System.Threading.Tasks;

namespace _002_Tasks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main Thread start.");

            var task1 = new Task(MyTask);
            var task2 = new Task(MyTask);

            task1.Start();
            task2.Start();

            Console.WriteLine("task1 Id: " + task1.Id);
            Console.WriteLine("task2 Id: " + task2.Id);

            for (int i = 0; i < 60; i++)
            {
                Console.Write(".");
                Thread.Sleep(100);
            }

            Console.WriteLine();
            Console.WriteLine("Main thread has been completed. CurrentId = null? - {0}.", Task.CurrentId == null);

            Console.ReadLine();
        }

        static void MyTask()
        {
            Console.WriteLine("MyTask() # " + Task.CurrentId + " Start.");

            for (int count = 0; count < 10; count++)
            {
                Thread.Sleep(500);

                Console.WriteLine("MyTask() #" + Task.CurrentId + " count: " + count);
            }

            Console.WriteLine("MyTask() # " + Task.CurrentId + " Start.");
        }

    }
}
