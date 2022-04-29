using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace _005_AsyncAwait
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
        public int Operation()
        {
            Console.WriteLine($"Operation ThreadId {Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(2000);
            return 100;
        }

        public void OperationAsync()
        {
            Task<int> task = Task<int>.Factory.StartNew(Operation);
            TaskAwaiter<int> awaiter = task.GetAwaiter();
            Action continuation = () => Console.WriteLine($"Result : {awaiter.GetResult()}");
            awaiter.OnCompleted(continuation);
        }

        public async void OperationAsync1()
        {
            Task<int> task = Task<int>.Factory.StartNew(Operation);
            Console.WriteLine($"Result : {await task}");
        }
    }
}
