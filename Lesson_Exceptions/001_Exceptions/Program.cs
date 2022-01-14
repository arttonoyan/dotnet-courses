using System;

namespace _001_Exceptions
{
    // https://docs.microsoft.com/en-us/dotnet/standard/exceptions/exception-class-and-properties?redirectedfrom=MSDN
    // https://docs.microsoft.com/en-us/dotnet/api/system.systemexception?redirectedfrom=MSDN&view=net-6.0

    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 2;
            try
            {
                int a = 2 / (2 - n);
            }
            catch (Exception ex)
            {
                string text = ex.Message;
            }

            Console.ReadLine();
        }
    }
}
