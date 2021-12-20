using System;

namespace _001_Delegates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var myClass = new MyClass();

            var myAction = new MyAction(new MyClass().Method1);
            var myAction1 = new MyAction(myClass.Method2);

            myAction1.Invoke();
            //myAction.Invoke();

            //myAction();

            Console.ReadLine();
        }

        private delegate void MyAction();
    }
}
