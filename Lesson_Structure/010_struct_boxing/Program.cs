using System;

namespace _010_struct_boxing
{
    class Program
    {
        static void Main(string[] args)
        {
            IEquatable<MyStruct> equatable = new MyStruct 
            { 
                Field = 10 
            };
        }
    }

    struct MyStruct : IEquatable<MyStruct>
    {
        public int Field { get; set; }

        public bool Equals(MyStruct other)
        {
            return Field == other.Field;
        }
    }
}
