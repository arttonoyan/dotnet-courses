using System;
using System.Threading;

namespace _008_Tasks_Cancellation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var cts = new CancellationTokenSource();
            CancellationToken token = cts.Token;

            // User defined Class with its own method for cancellation
            var obj1 = new Worker("1");
            var obj2 = new Worker("2");
            var obj3 = new Worker("3");

            // Register the object's cancel method with the token's
            // cancellation request.
            token.Register(() => obj1.Dispose());
            token.Register(() => obj2.Dispose());
            token.Register(() => obj3.Dispose());

            Console.WriteLine("Cancellation set in token source...");
            //Request cancellation on the token.
            cts.Cancel();

            Console.ReadLine();

        }
    }

    class Worker
    {
        public string id;

        public Worker(string id)
        {
            this.id = id;
        }

        public void Dispose()
        {
            Console.WriteLine("Object {0} Cancel callback", id);
            // Perform object cancellation here.
        }
    }

}
