using System;
using System.Threading;
using System.Threading.Tasks;

namespace _006_AsyncAwait_Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Main ThreadId {Thread.CurrentThread.ManagedThreadId}");
            var my = new MyClass();
            var task = my.OperationAsync();

            task.ContinueWith(t => Console.WriteLine("Finished"));

            Console.ReadLine();
        }
    }

    public class MyClass
    {
        public void Operation()
        {
            Console.WriteLine($"Operation ThreadId {Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(2000);
        }

        public async Task OperationAsync()
        {
            await Task.Factory.StartNew(Operation);
        }
    }
}
