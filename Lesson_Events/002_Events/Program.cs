using System;

namespace _002_Events
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var methods = typeof(MyClass).GetMethods();

            var instance = new MyClass();

            instance.MyEvent += new EventDelegate(Handler1);
            instance.MyEvent += new EventDelegate(Handler2);
            instance.MyEvent += new EventDelegate(Handler2);
            instance.MyEvent += new EventDelegate(Handler2);
            instance.MyEvent += new EventDelegate(Handler2);

            instance.InvokeEvent();

            Console.WriteLine(new string('-', 20));

            instance.MyEvent -= new EventDelegate(Handler2);
            instance.InvokeEvent();

            Console.ReadKey();
        }

        static private void Handler1()
        {
            Console.WriteLine("Event Handler 1");
        }

        static private void Handler2()
        {
            Console.WriteLine("Event Handler 2");
        }
    }

    public delegate void EventDelegate();

    public class MyClass
    {
        private int count;
        private EventDelegate myEvent;

        // The implementation of the add and remove accessors for the event.
        public event EventDelegate MyEvent
        {
            add
            {
                //myEvent += value;
                if (count < 2)
                {
                    myEvent += value;
                    count++;
                }
            }
            remove
            {
                //myEvent -= value;
                if (count != 0)
                {
                    myEvent -= value;
                    count--;
                }
            }
        }

        public void InvokeEvent()
        {
            myEvent.Invoke();
        }
    }
}
