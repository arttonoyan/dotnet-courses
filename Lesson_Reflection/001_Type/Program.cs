using System;

namespace _001_Type
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var my = new MyClass();

            Type t1 = my.GetType();
            Type t2 = typeof(MyClass);
            Type t3 = Type.GetType("_001_Type.MyClass");

            bool isClass = t1.IsClass;
            bool isValueType = t1.IsValueType;
            bool isAbstract = t1.IsAbstract;
            bool isArray = t1.IsArray;
            bool isGenericType = t1.IsGenericType;
            Type baseType = t1.BaseType;
        }
    }

    public class MyClass
    { }
}
