using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _009_Tasks_Cancellation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var parentTask = new Task(() =>
            {
                var cts = new CancellationTokenSource();
                
                var tf = new TaskFactory(cts.Token,
                    TaskCreationOptions.AttachedToParent,
                    TaskContinuationOptions.ExecuteSynchronously,
                    TaskScheduler.Default);

                var childTasks = new[]
                {
                    tf.StartNew(() => Sum(n: 30000, delay: 4000, cts.Token)),
                    tf.StartNew(() => Sum(n: 20, delay: 0, cts.Token)),
                    tf.StartNew(() => Sum(n: int.MaxValue, delay: 0, cts.Token))
                };

                // If any child throws, cancel all
                foreach (var childTask in childTasks)
                {
                    childTask.ContinueWith(t => cts.Cancel(), TaskContinuationOptions.OnlyOnFaulted);
                }

                tf.ContinueWhenAll(childTasks,
                        completedTasks => completedTasks.Where(t => t.Status == TaskStatus.RanToCompletion)
                            .Max(t => t.Result),
                        CancellationToken.None)
                    .ContinueWith(t => Console.WriteLine($"The max is {t.Result}"),
                        TaskContinuationOptions.ExecuteSynchronously);
            });

            parentTask.ContinueWith(t =>
            {
                var sb = new StringBuilder();
                sb.Append("The following exception occurred:" + Environment.NewLine);

                if (t.Exception != null)
                {
                    t.Exception.Handle(ex =>
                    {
                        return ex is OverflowException;
                    });
                }

                foreach (var exception in t.Exception.Flatten().InnerExceptions)
                {
                    sb.AppendLine("  " + exception.GetType());

                    Console.WriteLine(sb.ToString());
                }
            }, TaskContinuationOptions.OnlyOnFaulted);

            parentTask.Start();

            Console.ReadLine();
        }

        private static int Sum(int n, int delay, CancellationToken token)
        {
            Console.WriteLine($"Sum calculation in thread: {Thread.CurrentThread.ManagedThreadId}");

            int sum = 0;
            if (delay > 0)
            {
                Thread.Sleep(delay);
            }

            for (int i = 0; i < n; i++)
            {
                token.ThrowIfCancellationRequested();
                checked
                {
                    sum += i;
                }
            }

            return sum;
        }
    }
}
