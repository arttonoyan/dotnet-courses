using System;

namespace _007_Exceptions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var my = new MyClass();
            try
            {
                my.CatchInner();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException.Message);
            }

            Console.ReadLine();
        }
    }

    public class MyClass
    {
        public void ThrowInner()
        {
            throw new Exception("Inner Exception.");
        }

        public void CatchInner()
        {
            try
            {
                ThrowInner();
            }
            catch (Exception ex)
            {
                throw new Exception("Out Exception", ex);
            }
        }
    }
}
