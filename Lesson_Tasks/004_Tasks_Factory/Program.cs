using System;
using System.Threading;
using System.Threading.Tasks;

namespace _004_Tasks_Factory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main Thread start.");

            var task = Task.Factory.StartNew(MyTask);

            //task.Start();

            task.Wait();
            Console.WriteLine("task1 Id: " + task.Id);

            for (int i = 0; i < 10; i++)
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

            Console.WriteLine("MyTask() # " + Task.CurrentId + " End.");
        }
    }
}
