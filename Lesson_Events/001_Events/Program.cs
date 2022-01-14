using System;

namespace _001_Events
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var instance = new MyClass();

            instance.myEvent += new EventDelegate(Handler1);
            instance.myEvent += Handler2;

            instance.InvokeEvent();

            Console.WriteLine(new string('-', 20));

            instance.myEvent -= new EventDelegate(Handler2);

            //instance.InvokeEvent();

            Console.ReadKey();
        }

        static private void Handler1()
        {
            //Обработчик события
            Console.WriteLine("Event Handler 1");
        }

        static private void Handler2()
        {
            //Обработчик события
            Console.WriteLine("Event Handler 2");
        }
    }

    public delegate void EventDelegate();

    public class MyClass
    {
        public event EventDelegate myEvent = null;

        public void InvokeEvent()
        {
            var handler = myEvent;
            if (handler != null)
                handler.Invoke();
        }
    }
}
