using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace _011_Yield_DataRepository
{
    public static class DataRepositoryExtensions
    {
        public static IEnumerable<TModel> GetExecuter<TModel>(this IDataRepository repository, string query, Func<IDataRecord, TModel> mapper)
            where TModel : class, new()
            => repository.GetExecuter(query).Select(mapper);
    }
}
