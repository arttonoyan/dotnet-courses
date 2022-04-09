using System;
using System.Threading;

namespace _014_Thread_Volatile
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main: run thread in 2 second");

            var tester = new ReorderTest();
            tester.Start();
            
            Console.WriteLine("Finish.");
        }
    }

    class ReorderTest
    {
        private volatile int _a;

        public void Start()
        {
            var thread = new Thread(Worker);
            thread.Start();

            Thread.Sleep(2000);
            Console.WriteLine("Waiting for the thread to complete.");
            _a = 0;
            thread.Join();
        }

        private void Worker()
        {
            _a = 1;
            while (_a == 1)
            {
                //...
            }
        }
    }
}
