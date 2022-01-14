using System;

namespace _013_Exceptions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //throw new Exception("Exception");
                //throw new MyExceptionA("MyExceptionA");
                throw new MyExceptionB("MyExceptionB");
            }
            catch (MyExceptionB ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (MyExceptionA ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
    }

    class MyExceptionA : Exception
    {
        public MyExceptionA(string message)
            : base(message)
        { }
    }

    class MyExceptionB : MyExceptionA
    {
        public MyExceptionB(string message)
            : base(message)
        { }
    }
}
