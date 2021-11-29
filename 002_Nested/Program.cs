using System;

namespace _002_Nested
{
    class Program
    {
        static void Main(string[] args)
        {
            var instance = new MyClass.Nested();
            instance.ChangeField(10);

            MyClass.PrintField();

            Console.ReadKey();
        }
    }

    class MyClass
    {
        private static int field = 0;

        public static void PrintField()
        {
            Console.WriteLine("field: " + field);
        }

        public class Nested
        {
            public void ChangeField(int a)
            {
                field = a;

                Console.WriteLine(field);
            }
        }
    }
}
