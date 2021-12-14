using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _012_Yield_Stream
{
    static class StreamExtensions
    {
        public static IEnumerable<byte> AsEnumerable(this Stream source)
        {
            return Repeat(source.ReadByte).TakeUntil(-1).Select(p => (byte)p);
        }

        public static IEnumerable<byte> FirstLine(this Stream source)
        {
            return Repeat(source.ReadByte).TakeUntil('\n').Or(-1).Select(p => (byte)p);
        }

        public static IEnumerable<List<byte>> Lines(this Stream source)
        {
            while (true)
            {
                var en = FirstLine(source).ToList();
                if (en.Count == 0)
                    yield break;
                else
                {
                    yield return en;
                    source.Position++;
                }
            }
        }

        public static IEnumerable<int> Or(this IEnumerable<int> source, int value)
        {
            return TakeUntil(source, value);
        }

        public static IEnumerable<int> TakeUntil(this IEnumerable<int> source, int value)
        {
            foreach (var item in source)
            {
                if (item == value)
                    yield break;
                else
                    yield return item;
            }
        }

        public static IEnumerable<T> Repeat<T>(this Func<T> func)
        {
            while (true)
                yield return func.Invoke();
        }
    }

}
