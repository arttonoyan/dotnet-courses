using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace _011_Yield_DataRepository
{
    public static class DataRepositoryExtensions
    {
        public static IEnumerable<TModel> GetExecuter<TModel>(this IDataRepository repository, string query, Func<IDataRecord, TModel> mapper)
            where TModel : class, new()
            => repository.GetExecuter(query).Select(mapper);

        public static IAsyncEnumerable<TModel> GetAsyncExecuter<TModel>(this IDataRepository repository, string query, Func<IDataRecord, TModel> mapper, CancellationToken cancellationToken = default)
            where TModel : class, new()
            => repository
                .GetAsyncExecuter(query)
                .SelectAsync(mapper, cancellationToken);

        public static async IAsyncEnumerable<TResult> SelectAsync<TSource, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, TResult> selector, [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            await foreach (var item in source.WithCancellation(cancellationToken))
            {
                yield return selector(item);
            }
        }
    }
}
