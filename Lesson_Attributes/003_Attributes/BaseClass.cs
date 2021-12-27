using System;

namespace _003_Attributes
{
    [My("Base", "1/1/1111")]
    abstract class BaseClass
    {
        public BaseClass()
        {
            Console.WriteLine("Ctor BaseClass!!!");
        }
    }
}
