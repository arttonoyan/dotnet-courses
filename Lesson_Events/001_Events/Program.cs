using System;

namespace _001_Events
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var instance = new MyClass();

            instance.myEvent += new Action(Handler1);
            instance.myEvent += Handler2;

            instance.InvokeEvent();

            Console.WriteLine(new string('-', 20));

            instance.myEvent -= new Action(Handler2);

            //instance.InvokeEvent();

            Console.ReadKey();
        }

        private static void Handler1()
        {
            Console.WriteLine("Event Handler 1");
        }

        private static void Handler2()
        {
            Console.WriteLine("Event Handler 2");
        }
    }

    public class MyClass
    {
        public event Action myEvent = null;

        public void InvokeEvent()
        {
            var handler = myEvent;
            if (handler != null)
                handler.Invoke();
        }
    }
}
