using System;

namespace _012_Exceptions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                throw null;
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
    }
}
