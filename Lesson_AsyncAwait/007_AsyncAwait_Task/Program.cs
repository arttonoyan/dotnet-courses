using System;
using System.Threading;
using System.Threading.Tasks;

namespace _007_AsyncAwait_Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Main ThreadId {Thread.CurrentThread.ManagedThreadId}");
            var my = new MyClass();
            var task = my.OperationAsync();

            task.ContinueWith(t => Console.WriteLine($"Result: {t.Result}"));

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

        public async Task<int> OperationAsync()
        {
            return await Task.Factory.StartNew(Operation);
        }
    }
}
