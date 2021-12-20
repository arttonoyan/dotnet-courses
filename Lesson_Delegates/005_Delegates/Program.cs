using System;

namespace _005_Delegates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sum = 10;

            GetSum getSum = delegate (int[] values)
            {
                //int sum = 0;
                foreach (int value in values)
                {
                    sum += value;
                }
                return sum;
            };

            //GetSum getSum1 = new GetSum(Sum1);

            Console.WriteLine("Sum = " + getSum(10, 20, 30));
            Console.WriteLine("Sum = " + getSum(5, 1));

            Console.ReadLine();
        }

        public static int Sum1(params int[] values)
        {
            int sum = 0;
            foreach (int value in values)
            {
                sum += value;
            }
            return sum;
        }

        //Foo function
        public delegate int GetSum(params int[] values);
    }
}
