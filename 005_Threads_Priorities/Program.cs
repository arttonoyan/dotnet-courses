using System;
using System.Threading;

namespace _005_Threads_Priorities
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Started");

            var priorityTest = new PriorityTest();

            var thread1 = new Thread(priorityTest.ThreadMethod) { Name = "Thread 1" };
            var thread2 = new Thread(priorityTest.ThreadMethod)
            {
                Name = "Thread 2",
                Priority = ThreadPriority.BelowNormal
            };
            var thread3 = new Thread(priorityTest.ThreadMethod)
            {
                Name = "Thread 3",
                Priority = ThreadPriority.Highest
            };
            var thread4 = new Thread(priorityTest.ThreadMethod) { Name = "Thread 4" };
            var thread5 = new Thread(priorityTest.ThreadMethod)
            {
                Name = "Thread 5",
                Priority = ThreadPriority.BelowNormal
            };
            var thread6 = new Thread(priorityTest.ThreadMethod)
            {
                Name = "Thread 6",
                Priority = ThreadPriority.Highest
            };
            var thread7 = new Thread(priorityTest.ThreadMethod) { Name = "Thread 7" };
            var thread8 = new Thread(priorityTest.ThreadMethod)
            {
                Name = "Thread 8",
                Priority = ThreadPriority.BelowNormal
            };
            var thread9 = new Thread(priorityTest.ThreadMethod)
            {
                Name = "Thread 9",
                Priority = ThreadPriority.Highest
            };
            var thread10 = new Thread(priorityTest.ThreadMethod) { Name = "Thread 10" };
            var thread11 = new Thread(priorityTest.ThreadMethod)
            {
                Name = "Thread 11",
                Priority = ThreadPriority.BelowNormal
            };
            var thread12 = new Thread(priorityTest.ThreadMethod)
            {
                Name = "Thread 12",
                Priority = ThreadPriority.Highest
            };
            var thread13 = new Thread(priorityTest.ThreadMethod) { Name = "Thread 13" };
            var thread14 = new Thread(priorityTest.ThreadMethod)
            {
                Name = "Thread 14",
                Priority = ThreadPriority.Lowest
            };
            var thread15 = new Thread(priorityTest.ThreadMethod)
            {
                Name = "Thread 15",
                Priority = ThreadPriority.Highest
            };

            thread1.Start();
            thread2.Start();
            thread3.Start();
            thread4.Start();
            thread5.Start();
            thread6.Start();
            thread7.Start();
            thread8.Start();
            thread9.Start();
            thread10.Start();
            thread11.Start();
            thread12.Start();
            thread13.Start();
            thread14.Start();
            thread15.Start();
            // Allow counting for 10 seconds.
            Thread.Sleep(1000);
            priorityTest.LoopSwitch = false;

            Console.WriteLine("Finished");
        }
    }

    internal class PriorityTest
    {
        private static bool loopSwitch;
        
        [ThreadStatic] 
        private static long threadCount;

        public PriorityTest()
        {
            loopSwitch = true;
        }

        public bool LoopSwitch { get; set; }

        public void ThreadMethod()
        {
            while (loopSwitch)
            {
                threadCount++;
                //Thread.Sleep(0);
                //Thread.Yield();
            }

            Console.WriteLine("{0,-11} with {1,11} priority " +
                              "has a count = {2,13:N0}", Thread.CurrentThread.Name,
                Thread.CurrentThread.Priority.ToString(), threadCount);
        }

        // after calling Thread.Yield(), time-slice is given only to those threads who are running at the same processor with current thread.
        //     Thread.Yield() has a boolean return value which indicates that whether there were any threads who has received time-slice or not, but Thread.Sleep() has not return value.
        //     Thread.Sleep(0) prevents time-slice being handed over to threads with lower priorities. So it is more prone to starvation. But Thread.Yield() doesn't care to thread priorities, so starvation is less to happen.
    }
}
