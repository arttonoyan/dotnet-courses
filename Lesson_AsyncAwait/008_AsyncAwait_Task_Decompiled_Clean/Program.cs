using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace _008_AsyncAwait_Task_Decompiled_Clean
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

        public Task<int> OperationAsync(int arg)
        {
            AsyncStateMachine stateMachine = new();
            stateMachine.outer = this;
            stateMachine.builder = AsyncTaskMethodBuilder<int>.Create();
            stateMachine.state = -1;
            stateMachine.arg = arg;

            stateMachine.builder.Start(ref stateMachine);

            return stateMachine.builder.Task;
        }

        [CompilerGenerated]
        [StructLayout(LayoutKind.Auto)]
        private class AsyncStateMachine : IAsyncStateMachine
        {
            //public AsyncVoidMethodBuilder builder; // for void OperationAsync
            public AsyncTaskMethodBuilder<int> builder;   // for Task OperationAsync
            public MyClass outer;
            public int state;
            public int arg;

            TaskAwaiter<int> awaiter;

            void IAsyncStateMachine.MoveNext()
            {
                if (state == -1)
                {
                    awaiter = Task<int>.Factory.StartNew(() => outer.Operation(arg)).GetAwaiter();

                    state = 0;

                    var stateMachine = this;
                    builder.AwaitOnCompleted(ref awaiter, ref stateMachine);
                    return;
                }

                //The task is marked as completed successfully.
                int result = awaiter.GetResult();
                builder.SetResult(result);
            }

            void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
            {
                this.builder.SetStateMachine(stateMachine);
            }
        }
    }
}
