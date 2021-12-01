using System;

namespace _001_struct
{
    class Program
    {
        static void Main(string[] args)
        {
            //int a = 10;
            //ValueType vt = a;
            MyStruct ms;

            ms.field = 10;

            Console.WriteLine(ms.field);

            Console.ReadLine();

        }
    }

    struct MyStruct
    {
        public int field;
    }

}
