using _015_Exceptions.Extensions;
using System;

namespace _015_Exceptions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] nums = CreateRandomNumArr(10000);

            DateTime now = DateTime.Now;
            for (int i = 0; i < nums.Length; i++)
            {
                int num = nums[i].TryCatchToInt32();
            }

            Console.Write("Try-Catch: ");
            Console.WriteLine((DateTime.Now - now).ToString(@"ss\.fffffff"));

            Console.WriteLine(new string('*', 20));

            now = DateTime.Now;
            for (int i = 0; i < nums.Length; i++)
            {
                int num = nums[i].ToInt32();
            }

            Console.Write("TryParse: ");
            Console.WriteLine((DateTime.Now - now).ToString(@"ss\.fffffff"));

            Console.ReadLine();
        }

        static string[] CreateRandomNumArr(int count)
        {
            var arr = new string[count];
            var rnd = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(0, 10000).ToString();
            }

            return arr;
        }
    }
}
