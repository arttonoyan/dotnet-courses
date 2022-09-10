using System;

namespace _001_Delegates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var myClass = new MyClass { Id = 1003 };

            var myAction = new MyAction(myClass.Method1);
            var myAction1 = new MyAction(myClass.Method2);

            myAction1.Invoke();
            myAction();

            var my2 = new MyClass { Id = -10 };
            myAction.Method.Invoke(myAction.Target, null);


            Console.ReadLine();
        }

        private delegate void MyAction();
    }
}
