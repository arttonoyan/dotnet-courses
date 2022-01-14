using System;

namespace _004_Exceptions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                throw new MyException();
            }
            catch (MyException ex)
            {
                ex.Method();
            }

            Console.ReadLine();
        }
    }

    class MyException : Exception
    {
        public void Method()
        {
            Console.WriteLine("My Custom Exception.");
        }
    }
}
