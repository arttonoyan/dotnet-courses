using System;

namespace _009_Exceptions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Method(1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Finally");
            }

            Console.ReadLine();
        }

        static void Method(int i)
        {
            int[] arr = new int[1024 * 1024 * 1024 / 4];
            Console.WriteLine("Rec " + i);
            Method(++i);
        }
    }
}
