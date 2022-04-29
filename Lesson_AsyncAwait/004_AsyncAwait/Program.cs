using System;
using System.Threading;
using System.Threading.Tasks;

namespace _004_AsyncAwait
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Main ThreadId {Thread.CurrentThread.ManagedThreadId}");
            var my = new MyClass();
            my.OperationAsync();

            Console.ReadLine();
        }
    }

    public class MyClass
    {
        public void Operation()
        {
            Console.WriteLine($"Operation ThreadId {Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine("Start");
            Thread.Sleep(2000);
            Console.WriteLine("End");
        }

        public async void OperationAsync()
        {
            Console.WriteLine($"OperationAsync (Part 1) ThreadId {Thread.CurrentThread.ManagedThreadId}\n");

            var task = new Task(Operation);
            task.Start();
            await task;

            Console.WriteLine($"\nOperationAsync (Part 2) ThreadId {Thread.CurrentThread.ManagedThreadId}");
        }
    }
}
