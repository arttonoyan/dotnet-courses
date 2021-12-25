using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002_Reflection
{
    public class MyClass : IInterface1, IInterface2
    {
        // Fields.
        // 
        public int myint;
        private readonly string mystring = "Hello";

        // Constructors.
        public MyClass() { }
        public MyClass(int i)
        {
            this.myint = i;
        }

        // Properties.
        public int myProp
        {
            get { return myint; }
            set { myint = value; }
        }

        public string MyString
        {
            get { return mystring; }
        }

        // Methods.

        public void Method1() { }
        public void Method2() { }

        private void Method3(string str, string str2)
        {
            Console.WriteLine(str + str2);
        }
        public void myMethod(int p1, string p2) { }
    }
}
