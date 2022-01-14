using System;
using System.Linq;

namespace _002_Exceptions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            object obj = null;
            try
            {
                if (obj == null)
                    throw new Exception("Ha ha ha!!!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }

        static int GetMax(int[] arr)
        {
            if (arr == null)
                throw new Exception("Array is null");

            return arr.Max();
        }
    }
}
