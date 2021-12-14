using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _012_Yield_Stream
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream stream = new FileStream("test.txt", FileMode.Open, FileAccess.Read);

            var allBytes1 = stream.AsEnumerable().ToArray();
            var allBytes2 = File.ReadAllBytes("test.txt");

            bool isTrue = Equals(allBytes1, allBytes2);

            stream.Dispose();

            Console.ReadLine();
        }

        private static bool Equals(byte[] bytes1, byte[] bytes2)
        {
            if (bytes1.Length != bytes2.Length)
                return false;

            for (int i = 0; i < bytes1.Length; i++)
            {
                if (bytes1[i] != bytes2[i])
                    return false;
            }

            return true;
        }
    }
}
