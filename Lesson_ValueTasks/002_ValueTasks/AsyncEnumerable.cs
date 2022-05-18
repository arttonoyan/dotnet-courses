using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace System.Linq
{
    public static class AsyncEnumerable_ValueTask
    {
        /// <summary>
        /// Asynchronously creates a <see cref="List{T}" /> from an <see cref="IAsyncEnumerable{T}" /> by enumerating it asynchronously.
        /// </summary>
        public static async ValueTask<List<TSource>> ToListAsync_ValueTask<TSource>(this IAsyncEnumerable<TSource> source, CancellationToken cancellationToken = default)
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
        public static async ValueTask<TSource?> FirstOrDefaultAsync_ValueTask<TSource>(this IAsyncEnumerable<TSource> source, CancellationToken cancellationToken = default)
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
