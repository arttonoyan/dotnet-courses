using System;
using System.Threading;
using System.Threading.Tasks;

namespace _005_Tasks_Factory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main Thread start.");

            var task = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("MyTask() # " + Task.CurrentId + " Start.");

                for (int count = 0; count < 10; count++)
                {
                    Thread.Sleep(500);

                    Console.WriteLine("MyTask() #" + Task.CurrentId + " count: " + count);
                }

                Console.WriteLine("MyTask() # " + Task.CurrentId + " Complete.");
            });

            task.Wait();

            Console.WriteLine();
            Console.WriteLine("Main thread has been completed. CurrentId = null? - {0}.", Task.CurrentId == null);

            Console.ReadLine();

        }
    }
}
