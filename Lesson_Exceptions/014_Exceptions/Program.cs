using System;

namespace _014_Exceptions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var my = new MyClass())
            {
                // ...
            }

            #region Using Block

            MyClass my1 = null;
            try
            {
                my1 = new MyClass();
            }
            finally
            {
                my1.Dispose();
            }

            #endregion

            Console.ReadLine();
        }
    }

    class MyClass : IDisposable
    {
        public void Dispose()
        {
            Console.WriteLine("Disposed");
        }
    }
}
