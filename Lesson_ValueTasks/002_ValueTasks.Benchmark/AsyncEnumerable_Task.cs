using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _002_ValueTasks
{
    public static class AsyncEnumerable_Task
    {
        /// <summary>
        /// Asynchronously creates a <see cref="List{T}" /> from an <see cref="IAsyncEnumerable{T}" /> by enumerating it asynchronously.
        /// </summary>
        public static async Task<List<TSource>> ToListAsync_Task<TSource>(this IAsyncEnumerable<TSource> source, CancellationToken cancellationToken = default)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            var list = new List<TSource>();
            await foreach (var element in source.WithCancellation(cancellationToken))
            {
                list.Add(element);
            }

            return list;
        }

        /// <summary>
        /// Returns the first element of an async-enumerable sequence, or a default value if no such element exists.
        /// </summary>
        public static async Task<TSource> FirstOrDefaultAsync_Task<TSource>(this IAsyncEnumerable<TSource> source, CancellationToken cancellationToken = default)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            await foreach (var element in source.WithCancellation(cancellationToken))
            {
                return element;
            }

            return default;
        }
    }
}
