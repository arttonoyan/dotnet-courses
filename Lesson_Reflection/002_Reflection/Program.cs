using System;
using System.Reflection;

namespace _002_Reflection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var myClass = new MyClass();

            //Type type = myClass.GetType();
            //MethodInfo methodC = type.GetMethod("Method3", BindingFlags.Instance | BindingFlags.NonPublic);
            //methodC.Invoke(myClass, new object[] { "Barev", " From Private Method" });

            #region Show Information about class

            ListVariosStats(myClass);
            ListMethods(myClass);
            ListFields(myClass);
            ListProps(myClass);
            ListInterfaces(myClass);
            ListConstructors(myClass);

            #endregion

            #region 

            Console.WriteLine(new string('-', 60));
            Type type = myClass.GetType();

            // Call private method
            MethodInfo methodC = type.GetMethod("Method3", BindingFlags.Instance | BindingFlags.NonPublic);
            methodC.Invoke(myClass, new [] { "Hello", " world!" });

            // Change private value
            FieldInfo mystring = type.GetField("mystring", BindingFlags.Instance | BindingFlags.NonPublic);
            mystring.SetValue(myClass, "private world!");

            Console.WriteLine(myClass.MyString);

            #endregion

            Console.ReadKey();
        }

        // Get other information about Class1.
        static void ListVariosStats(MyClass cl)
        {
            Console.WriteLine(new string('_', 30) + " Information Class1" + "\n");
            Type t = cl.GetType();

            Console.WriteLine("Full Name:              {0}", t.FullName);
            Console.WriteLine("Base Type:              {0}", t.BaseType);
            Console.WriteLine("Is Abstract:            {0}", t.IsAbstract);
            Console.WriteLine("Is Sealed:              {0}", t.IsSealed);
            Console.WriteLine("Is class:               {0}", t.IsClass);
        }

        // Get information about all methods Class1.
        static void ListMethods(MyClass cl)
        {
            Console.WriteLine(new string('_', 30) + " Class1 methods" + "\n");

            Type t = cl.GetType();
            MethodInfo[] mi = t.GetMethods(
                BindingFlags.Instance | 
                BindingFlags.Public | 
                BindingFlags.NonPublic | 
                BindingFlags.DeclaredOnly
            );

            foreach (MethodInfo m in mi)
                Console.WriteLine("Method: {0}", m.Name);
        }

        // Get information about all fields Class1.
        static void ListFields(MyClass cl)
        {
            Console.WriteLine(new string('_', 30) + " Class1 Fields" + "\n");

            Type t = cl.GetType();
            FieldInfo[] fi =
                t.GetFields(BindingFlags.Instance
                    | BindingFlags.Static
                    | BindingFlags.Public
                    | BindingFlags.NonPublic);

            foreach (FieldInfo f in fi)
                Console.WriteLine("Field: {0}", f.Name);
        }

        // Get information about all properties Class1.
        static void ListProps(MyClass cl)
        {
            Console.WriteLine(new string('_', 30) + " Class1 Properties" + "\n");

            Type t = cl.GetType();
            PropertyInfo[] pi = t.GetProperties();

            foreach (PropertyInfo p in pi)
                Console.WriteLine("Property: {0}", p.Name);
        }

        // Get information about all interfaces Class1.
        static void ListInterfaces(MyClass cl)
        {
            Console.WriteLine(new string('_', 30) + " Class1 Interfaces" + "\n");

            Type t = cl.GetType();

            Type[] it = t.GetInterfaces();

            foreach (Type i in it)
                Console.WriteLine("Interface: {0}", i.Name);
        }

        // Get information about all constructors Class1.
        static void ListConstructors(MyClass cl)
        {
            Console.WriteLine(new string('_', 30) + " Class1 Constructors" + "\n");

            Type t = cl.GetType();
            ConstructorInfo[] ci = t.GetConstructors();

            foreach (ConstructorInfo m in ci)
                Console.WriteLine("Constructor: {0}", m.Name);
        }
    }
}
