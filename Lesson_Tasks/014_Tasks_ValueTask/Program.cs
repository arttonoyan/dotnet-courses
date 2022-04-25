using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace _014_Tasks_ValueTask
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            using var reader = new Reader(new FileStream("014_Tasks_ValueTask.exe", FileMode.Open, FileAccess.Read));
            long sum = 0;
            while (true)
            {
                var b = await reader.GetNextByteAsync();
                if (b == -1)
                    break;

                sum += b;
            }

            Console.WriteLine($"Sum of bytes: {sum}");
            Console.ReadLine();
        }
    }

    class Reader : IDisposable
    {
        private readonly byte[] buf = new byte[1024];
        private int pos = 0;
        private int len = 0;
        private readonly Stream stream;

        public Reader(Stream stream)
        {
            this.stream = stream;
        }

        public async ValueTask<int> GetNextByteAsync()
        {
            // If we've exhausted the current buffer, fetch another buffer
            if (pos >= len)
            {
                len = await stream.ReadAsync(buf);
                pos = 0;
            }

            // If there's anything left in the current buffer, return it
            if (pos < len)
            {
                return buf[pos++];
            }

            return -1;
        }

        public void Dispose()
        {
            stream.Dispose();
        }
    }
}
