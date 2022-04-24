using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace _003_Tasks_WaitAll_vs_WhenAll
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Main Thread start.");
            Console.ResetColor();

            var task = DoWorkAsync(3);

            for (int i = 0; i < 60; i++)
            {
                Console.Write(".");
                Thread.Sleep(100);
            }

            task.Wait();

            Console.WriteLine();
            Console.WriteLine("Main thread has been completed. CurrentId = null? - {0}.", Task.CurrentId == null);

            Console.ReadLine();
        }

        public static Task DoWorkAsync(int count)
        {
            var tastks = Enumerable
                .Range(0, count)
                .Select(p =>
                {
                    var task = new Task(Worker);
                    task.Start();
                    return task;
                });

            Task.WaitAll(tastks.ToArray());
            return Task.CompletedTask;
            //return Task.WhenAll(tastks);
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
