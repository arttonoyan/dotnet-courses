using System;
using System.Threading;

namespace _008_Tasks_Cancellation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var cts = new CancellationTokenSource();
            CancellationToken token = cts.Token;

            // User defined Class with its own method for cancellation
            var obj1 = new CancelableObject("1");
            var obj2 = new CancelableObject("2");
            var obj3 = new CancelableObject("3");

            // Register the object's cancel method with the token's
            // cancellation request.
            token.Register(() => obj1.Cancel());
            token.Register(() => obj2.Cancel());
            token.Register(() => obj3.Cancel());

            Console.WriteLine("Cancellation set in token source...");
            //Request cancellation on the token.
            cts.Cancel();
            // Call Dispose when we're done with the CancellationTokenSource.
            cts.Dispose();

            Console.ReadLine();

        }
    }

    class CancelableObject
    {
        public string id;

        public CancelableObject(string id)
        {
            this.id = id;
        }

        public void Cancel()
        {
            Console.WriteLine("Object {0} Cancel callback", id);
            // Perform object cancellation here.
        }
    }

}
