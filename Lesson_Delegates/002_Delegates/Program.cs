using System;

namespace _002_Delegates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var instance = new MyClass();

            MyAction myAction = new MyAction(instance.Method);

            //string text = myAction.Invoke("Delegate!!");
            WriteDelInfo(myAction);

            //Console.WriteLine( text);

            //myAction();

            Console.ReadLine();
        }

        public static void WriteDelInfo(MyAction ma)
        {
            string text = ma.Invoke("AAA");
            Console.WriteLine(text);
        }

        public delegate string MyAction(string name);
    }
}
