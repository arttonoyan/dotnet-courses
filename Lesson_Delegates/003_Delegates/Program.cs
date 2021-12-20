using System;

namespace _003_Delegates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var instance = new MyClass();

            var myAction1 = new MyAction(instance.Method1);
            var myAction2 = new MyAction(instance.Method2);
            var myAction3 = new MyAction(instance.Method3);

            //myAction1();

            //MyAction myAction = myAction2 + myAction1 + myAction3;
            //MyAction myAction = myAction1 + myAction2 + myAction3;
            MyAction myAction = myAction2 + myAction2 + myAction3;
            myAction.Invoke();
            myAction -= myAction3;

            myAction.Invoke();

            //myAction();

            Console.ReadLine();
        }

        public delegate void MyAction();
    }
}
