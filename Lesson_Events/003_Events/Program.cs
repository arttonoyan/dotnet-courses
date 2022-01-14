using System;

namespace _003_Events
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var instance = new DerivedClass();

            instance.MyEvent += Handler1;
            instance.MyEvent += Handler2;

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

    interface IInterface
    {
        event EventDelegate MyEvent; // Abstract event.
    }

    public class BaseClass : IInterface
    {
        EventDelegate myEvent;

        public virtual event EventDelegate MyEvent // Virtual event.
        {
            add { myEvent += value; }
            remove { myEvent -= value; }
        }

        public void InvokeEvent()
        {
            myEvent.Invoke();
        }
    }

    public class DerivedClass : BaseClass
    {
        public override event EventDelegate MyEvent
        {
            add
            {
                base.MyEvent += value;
                Console.WriteLine($"A handler was attached to the base class event - {value.Method.Name}");
            }
            remove
            {
                base.MyEvent -= value;
                Console.WriteLine($"A handler was detached from the base class event - {value.Method.Name}");
            }
        }
    }
}
