using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace _002_AsyncAwait_Decompiled
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

        public void OperationAsync()
        {
            MyClass.AsyncStateMachine stateMachine = new();
            stateMachine.outer = this;
            stateMachine.builder = AsyncVoidMethodBuilder.Create();
            stateMachine.state = -1;
            stateMachine.builder.Start<MyClass.AsyncStateMachine>(ref stateMachine);
        }

        [CompilerGenerated]
        [StructLayout(LayoutKind.Auto)]
        private class AsyncStateMachine : IAsyncStateMachine
        {
            public MyClass outer;
            public AsyncVoidMethodBuilder builder;
            public int state;
            private TaskAwaiter awaiter;

            void IAsyncStateMachine.MoveNext()
            {
                int num1 = this.state;
                try
                {
                    TaskAwaiter awaiter;
                    int num2;
                    if (num1 == 0 || num1 != 1)
                    {
                        Task task = new Task(new Action(outer.Operation));
                        task.Start();
                        awaiter = task.GetAwaiter();
                        if (!awaiter.IsCompleted)
                        {
                            this.state = num2 = 1;
                            this.awaiter = awaiter;
                            AsyncStateMachine stateMachine = this;
                            this.builder.AwaitOnCompleted<TaskAwaiter, MyClass.AsyncStateMachine>(ref awaiter, ref stateMachine);
                            return;
                        }
                    }
                    else
                    {
                        awaiter = this.awaiter;
                        this.awaiter = new TaskAwaiter();
                        this.state = num2 = -1;
                    }
                }
                catch (Exception ex)
                {
                    this.state = -2;
                    this.builder.SetException(ex);
                    return;
                }
            }

            public void SetStateMachine(IAsyncStateMachine stateMachine)
            {
                this.builder.SetStateMachine(stateMachine);
            }
        }
    }
}
