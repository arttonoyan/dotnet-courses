using System;
using System.ComponentModel;
using System.Reflection;

namespace _002_Attributes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //MyClass my = new MyClass();
            //MyClass.Method();

            Type type = typeof(MyClass);

            MyAttribute attribute = null;

            // Analysis of type attributes
            // Get all attributes of a given Attribute type (false  - without checking base classes).
            object[] attributes = type.GetCustomAttributes(false);

            foreach (object attributeType in attributes)
            {
                attribute = attributeType as MyAttribute;
                Console.WriteLine("Type Analysis  : Number = {0}, Date = {1}", attribute.Number, attribute.Date);
            }

            // Analysis of method attributes.
            // Get public static method - Method.
            MethodInfo method = type.GetMethod("Method", BindingFlags.Public | BindingFlags.Static);

            // Get all attributes of a given Attribute type (false - without checking base classes).
            attributes = method.GetCustomAttributes(typeof(MyAttribute), false);

            foreach (MyAttribute attrib in attributes)
            {
                Console.WriteLine("Анализ метода: Number = {0}, Date = {1}", attrib.Number, attrib.Date);
            }

            // Delay.
            Console.ReadLine();
        }
    }

    [My("5/28/2016", Number = 1)]
    public class MyClass
    {
        [Description("adsjfhskj")]
        [My("5/31/2016", Number = 2)]
        public static void Method()
        {
            Console.WriteLine("MyClass.Method()\n");
        }
    }
}
