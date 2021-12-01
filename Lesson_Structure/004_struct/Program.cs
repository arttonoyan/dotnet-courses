using System;

namespace _004_struct
{
    class Program
    {
        static void Main(string[] args)
        {
            //MyStruct ms = new MyStruct();
            var ms = new MyStruct(10);
            //ms.field = 10;
            Console.WriteLine(ms.field); // Can Use.

            Console.ReadLine();

        }
    }

    struct MyStruct
    {
        // Can't use default constructor.
        //public MyStruct()
        //{ }

        public MyStruct(int value)
        {
            this.field = value; // Can't add comment
            field1 = 0;
        }

        public int field;
        public int field1;
    }

}
