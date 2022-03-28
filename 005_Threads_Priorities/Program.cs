using System;
using System.Linq;
using System.Threading;

namespace _005_Threads_Priorities
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Started");
            Console.WriteLine();
            Console.ResetColor();

            var priorityTest = new PriorityTest();

            var rnd = new Random();
            var priorites = new[]
            {
                ThreadPriority.Lowest,
                ThreadPriority.BelowNormal,
                ThreadPriority.Normal,
                ThreadPriority.AboveNormal,
                ThreadPriority.Highest
            };

            var threads = Enumerable
                .Range(1, 15)
                .Select(index => new Thread(priorityTest.ThreadMethod)
                {
                    Name = $"Thread {index}",
                    Priority = priorites[rnd.Next(0, priorites.Length)]
                })
                .ToList();

            threads.ForEach(thread => thread.Start());

            // Allow counting for 40 seconds.
            Thread.Sleep(4000);
            priorityTest.LoopSwitch = false;

            Console.WriteLine();

            threads.ForEach(thread => thread.Join());

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();
            Console.WriteLine("Finished");
            Console.ResetColor();

            Console.ReadLine();
        }
    }

    internal class PriorityTest
    {
        [ThreadStatic]
        private static long threadCount;

        public PriorityTest()
        {
            LoopSwitch = true;
        }

        public volatile bool LoopSwitch;

        public void ThreadMethod()
        {
            Console.WriteLine($"{Thread.CurrentThread.Name} Started.");

            while (LoopSwitch)
            {
                threadCount++;
                //Thread.Sleep(0);
                Thread.Yield();
            }

            Console.WriteLine("{0,-11} with {1,11} priority " +
                              "has a count = {2,13:N0}", Thread.CurrentThread.Name,
                Thread.CurrentThread.Priority.ToString(), threadCount);
        }
    }
}
