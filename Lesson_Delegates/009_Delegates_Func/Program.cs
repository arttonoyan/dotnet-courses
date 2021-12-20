using System;

namespace _009_Delegates_Func
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<int[], int> GetMax = arr =>
            {
                int max = arr[0];
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] > max)
                        max = arr[i];
                }

                return max;
            };

            Func<int, int[]> GenerateArr = n =>
            {
                int[] arr = new int[n];
                Random rnd = new Random();
                for (int i = 0; i < n; i++)
                    arr[i] = rnd.Next(10, 100);

                return arr;
            };

            int[] arr1 = GenerateArr(10);
            int max1 = GetMax(arr1);

            Console.ReadLine();
        }
    }
}
