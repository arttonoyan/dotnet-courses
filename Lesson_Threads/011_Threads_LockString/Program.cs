using System;
using System.Collections.Generic;
using System.Threading;

namespace _011_Threads_LockString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var rnd = new Random();

            int count = 30;
            var worker1 = new Worker1();
            var threads1 = new Thread[count];

            var worker2 = new Worker2();
            var threads2 = new Thread[count];

            for (int i = 0; i < count; i += 2)
            {
                threads1[i] = new Thread(() => WorkerAddAction(worker1, rnd));
                threads1[i + 1] = new Thread(() => WorkerPrintAction(worker1, rnd));
            }

            for (int i = 0; i < count; i += 2)
            {
                threads2[i] = new Thread(() => WorkerAddAction(worker2, rnd));
                threads2[i + 1] = new Thread(() => WorkerPrintAction(worker2, rnd));
            }

            for (int i = 0; i < count; i += 2)
            {
                threads1[i].Start();
                threads1[i + 1].Start();

                threads2[i].Start();
                threads2[i + 1].Start();
            }

            Console.ReadLine();
        }

        static void WorkerAddAction(Worker1 worker, Random rnd)
        {
            int id = rnd.Next(1, 5);
            worker.TryAdd(id, id);
        }

        static void WorkerPrintAction(Worker1 worker, Random rnd)
        {
            int id = rnd.Next(1, 5);
            worker.TryPrint(id);
        }

        static void WorkerAddAction(Worker2 worker, Random rnd)
        {
            int id = rnd.Next(1, 5);
            worker.TryAdd(id, id);
        }

        static void WorkerPrintAction(Worker2 worker, Random rnd)
        {
            int id = rnd.Next(1, 5);
            worker.TryPrint(id);
        }
    }

    class Worker1
    {
        //private readonly string _lockObject = new object();
        private readonly string _lockObject = "test";
        private Dictionary<int, int> dic = new();

        public void TryAdd(int id, int value)
        {
            lock (_lockObject)
            {
                dic[id] = value;
            }
        }

        public void TryRemove(int id)
        {
            lock (_lockObject)
            {
                if (dic.ContainsKey(id))
                    dic.Remove(id);
            }
        }

        public void TryPrint(int id)
        {
            lock (_lockObject)
            {
                Thread.Sleep(5000);
                Console.ForegroundColor = ConsoleColor.Red;

                if (dic.TryGetValue(id, out int value))
                    Console.WriteLine($"[Worker1] id = {id}, value = {value}");

                Console.ResetColor();
            }
        }
    }

    class Worker2
    {
        //private readonly object _lockObject = new object();
        private readonly string _lockObject = "test";
        private Dictionary<int, int> dic = new Dictionary<int, int>();

        public void TryAdd(int id, int value)
        {
            lock (_lockObject)
            {
                dic[id] = value;
            }
        }

        public void TryRemove(int id)
        {
            lock (_lockObject)
            {
                if (dic.ContainsKey(id))
                    dic.Remove(id);
            }
        }

        public void TryPrint(int id)
        {
            lock (_lockObject)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;

                if (dic.TryGetValue(id, out int value))
                    Console.WriteLine($"[Worker2] id = {id}, value = {value}");

                Console.ResetColor();
            }
        }
    }
}
