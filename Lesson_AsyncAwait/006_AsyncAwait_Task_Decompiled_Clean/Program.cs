using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace _006_AsyncAwait_Task_Decompiled_Clean
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

        public Task OperationAsync()
        {
            AsyncStateMachine stateMachine = new();
            stateMachine.outer = this;
            stateMachine.builder = AsyncTaskMethodBuilder.Create();
            stateMachine.state = -1;
            stateMachine.builder.Start(ref stateMachine);

            return stateMachine.builder.Task;
        }

        [CompilerGenerated]
        [StructLayout(LayoutKind.Auto)]
        private class AsyncStateMachine : IAsyncStateMachine
        {
            //public AsyncVoidMethodBuilder builder; // for void OperationAsync
            public AsyncTaskMethodBuilder builder;   // for Task OperationAsync
            public MyClass outer;
            public int state;

            TaskAwaiter awaiter;

            void IAsyncStateMachine.MoveNext()
            {
                if (state == -1)
                {
                    awaiter = Task.Factory.StartNew(outer.Operation).GetAwaiter();

                    state = 0;

                    var stateMachine = this;
                    builder.AwaitOnCompleted(ref awaiter, ref stateMachine);
                    return;
                }

                //The task is marked as completed successfully.
                builder.SetResult();
            }

            void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
            {
                this.builder.SetStateMachine(stateMachine);
            }
        }
    }
}
