using System;

namespace _002_Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            var instance1 = new MyGenerics<int, int>(1, 2);
            Console.WriteLine(instance1.Variable1 + instance1.Variable2);

            var instance2 = new MyGenerics<string, int>("Number ", 1);
            Console.WriteLine(instance2.Variable1 + instance2.Variable2);

            MyGenerics<string, string> instance3 = new MyGenerics<string, string>("Hello ", "World");
            Console.WriteLine(instance3.Variable1 + instance3.Variable2);

            Console.ReadKey();
        }
    }

    class MyGenerics<TYPE1, TYPE2>
    {
        private TYPE1 variable1;
        private TYPE2 variable2;

        public MyGenerics(TYPE1 argument1, TYPE2 argument2)
        {
            this.variable1 = argument1;
            this.variable2 = argument2;
        }

        public TYPE1 Variable1
        {
            get { return this.variable1; }
            set { this.variable1 = value; }
        }

        public TYPE2 Variable2
        {
            get { return this.variable2; }
            set { this.variable2 = value; }
        }
    }
}
