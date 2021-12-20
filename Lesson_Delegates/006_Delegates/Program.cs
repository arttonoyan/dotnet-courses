using System;

namespace _006_Delegates
{
    // Lambda Expression
    internal class Program
    {
        public delegate int MyAction(int a1, int b1);

        static void Main(string[] args)
        {
            MyAction plus = (a, b) => a + b;
            MyAction minus = (a, b) => a - b;

            int res1 = plus(10, 5) + plus(10, 5);
            int res2 = minus(10, 5);

            #region

            MyAction action;

            // Lambda Method
            action = delegate (int a, int b)
            {
                return a + b;
            };
            Console.WriteLine("Lambda Method: 10 + 5 = " + action(10, 5));

            // Lambda Operator
            action = (a, b) =>
            {
                return a + b;
            };
            Console.WriteLine("Lambda Operator: 10 + 5 = " + action(10, 5));

            // Lambda Expression
            action = (a, b) => a + b;
            Console.WriteLine("Lambda Expression: 10 + 5 = " + action(10, 5));

            // Difference betweens "Lambda Operator" and "Lambda Expression"

            #endregion

            Console.ReadLine();
        }
    }
}
