using System;
using System.Collections.Generic;
using System.Threading;

namespace _008_Threads_Reader
{
    internal class Program
    {
        private static Dictionary<int, int> dic = new();

        static void Main(string[] args)
        {
            Console.WriteLine("Started...");
            var creater = new Thread(Creater);
            creater.Start();

            var remover = new Thread(Remover);
            remover.Start();

            var reader = new Thread(Reader);
            reader.Start();

            Console.WriteLine("Waiting to finish.");
            Console.ReadLine();
        }

        private static void Reader()
        {
            while (true)
            {
                int number = 10;

                if (dic.ContainsKey(number))
                    Console.WriteLine(dic[number]);

                //if(dic.TryGetValue(number, out int value))
                //    Console.WriteLine(value);
            }
        }

        private static void Creater()
        {
            while (true)
            {
                int number = 10;
                dic[number] = number;
            }
        }

        private static void Remover()
        {
            while (true)
            {
                int number = 10;
                dic.Remove(number);
            }
        }
    }
}
