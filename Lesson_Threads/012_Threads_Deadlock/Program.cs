using System;
using System.Threading;

namespace _012_Threads_Deadlock
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Singleton s = new Singleton();
            //s.GetInstance();

            var t1 = new Thread(Func1);
            t1.Start();

            var t2 = new Thread(Func2);
            t2.Start();

            Console.WriteLine("Finish");
            Console.ReadLine();
        }

        private static readonly object locker1 = new object();
        private static readonly object locker2 = new object();

        public static void Func1()
        {
            lock (locker1)
            {
                Thread.Sleep(1000);
                lock (locker2)
                {
                    Console.WriteLine("Barev from Func1");
                }
            }
        }

        public static void Func2()
        {
            lock (locker2)
            {
                Thread.Sleep(1000);
                lock (locker1)
                {
                    Console.WriteLine("Barev from Func2");
                }
            }
        }
    }

    public class Singleton
    {
        private static Singleton _instance = null;
        private static readonly object _lock = new object();

        public static Singleton GetInstance()
        {
            lock (_lock)
            {
                if (_instance == null) 
                    _instance = new Singleton();
                
                return _instance;
            }
        }
    }
}
