using System;
using System.IO;
using System.Threading.Tasks;

namespace _004_ValueTasks_Reader
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            using var reader = new ByteReader(new FileStream("004_ValueTasks_Reader.exe", FileMode.Open, FileAccess.Read));
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

    public class ByteReader : IDisposable
    {
        private readonly byte[] buf = new byte[1024];
        private int pos = 0;
        private int len = 0;
        private readonly Stream stream;

        public ByteReader(Stream stream)
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

        public async Task<int> GetNextByteAsync_Task()
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
