using System;

namespace _004_Delegates
{
    internal class Program
    {
        //Anonymous Methods
        static void Main(string[] args)
        {
            //MyAction myAction = new MyAction(delegate 
            //{
            //    Console.WriteLine("Hello Delegate!!!");
            //});

            myAction = delegate { Console.WriteLine("Hello Delegate!!!"); };
            CallDel();
            //myAction.Invoke();
            //myAction.Invoke();

            Console.ReadLine();
        }

        public static MyAction myAction;

        public static void CallDel()
        {
            myAction.Invoke();
        }

        public delegate void MyAction();
    }
}
