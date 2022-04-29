using System;
using System.Threading;
using System.Threading.Tasks;

namespace _008_AsyncAwait_Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Main ThreadId {Thread.CurrentThread.ManagedThreadId}");
            var my = new MyClass();
            var task = my.OperationAsync(100);

            task.ContinueWith(t => Console.WriteLine($"Result: {t.Result}"));

            Console.ReadLine();
        }
    }
    
    public class MyClass
    {
        public int Operation(int arg)
        {
            Console.WriteLine($"Operation ThreadId {Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(2000);
            return 2 * arg;
        }

        public async Task<int> OperationAsync(int arg)
        {
            return await Task<int>.Factory.StartNew(() => Operation(arg));
        }
    }
}
