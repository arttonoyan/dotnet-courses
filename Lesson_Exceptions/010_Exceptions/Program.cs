using System;

namespace _010_Exceptions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                throw new Exception();
            }
            catch (Exception ex)
            {
                throw new Exception("Exception from Catch.");

                //while(true)
                //    Console.WriteLine("Catch.");
            }
            finally
            {
                Console.WriteLine("Finally.");
            }

            Console.ReadLine();
        }
    }
}
