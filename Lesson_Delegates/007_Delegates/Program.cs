using System;

namespace _007_Delegates
{
    // Multicastdelegate example
    internal class Program
    {
        static void Main(string[] args)
        {
            MyAction action;
            action = delegate { Console.WriteLine("Lambda Method"); };
            action += () => { Console.WriteLine("Lambda Operator"); };
            action += () => Console.WriteLine("Lambda Expression");

            action();

            MyFunc<int, int, int> plus = (a, b) => a + b;
            int res = plus(5, 25);

            Console.ReadLine();
        }

        public delegate void MyAction();
        public delegate TResult MyFunc<T1, T2, TResult>(T1 arg1, T2 arg2);
    }
}
