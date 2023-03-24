using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace _005_Threads_Priorities
{
    internal class Program
    {
        [ThreadStatic]
        private static int count = 0;
        private static volatile bool breack = false;

        static void Main(string[] args)
        {
            var threads = Enum.GetValues(typeof(ThreadPriority))
                .Cast<ThreadPriority>()
                .OrderByDescending(p => p)
                .Select(priority => new Thread(Worker) { Priority = priority, Name = priority.ToString() })
                .ToList();

            threads.ForEach(t => t.Start());

            Thread.Sleep(2000);
            breack = true;
        }

        private static void Worker()
        {
            while (!breack)
            {
                count++;
            }

            decimal value = (decimal)count / 1000;            
            Console.WriteLine($"{Thread.CurrentThread.Name} - {Math.Round(value, 0)}");
        }
    }
}
