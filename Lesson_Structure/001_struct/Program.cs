using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _001_struct
{
    class Program
    {
        static void Main(string[] args)
        {
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
