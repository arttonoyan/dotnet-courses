using System;

namespace _002_struct
{
    class Program
    {
        static void Main(string[] args)
        {
            var ms = new MyStruct();
            ms.Field = 10;
            Console.WriteLine(ms.Field);

            Console.ReadLine();
        }
    }

    struct MyStruct
    {
        private int field;
        public int Field
        {
            get { return field; }
            set { /*field = value;*/ }
        }

        public void Show()
        {
            Console.WriteLine(field);
        }
    }
}
