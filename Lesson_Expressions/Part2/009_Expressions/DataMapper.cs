using System;
using System.Data;

namespace _009_Expressions
{
    public interface IDataMapper
    {
        Func<IDataRecord, TResult> GetOrCreate<TResult>()
            where TResult : class, new();
    }

    public class DataMapper : IDataMapper
    {
        private readonly IMapperBuilder _builder;
        private readonly ICache _cache;

        public DataMapper(IMapperBuilder mapperBuilder, ICache cache)
        {
            _builder = mapperBuilder;
            _cache = cache;
        }

        public Func<IDataRecord, TResult> GetOrCreate<TResult>()
            where TResult : class, new()
        {
            if (_cache.TryGetFunc<IDataRecord, TResult>(out var func))
                return func;

            var exp = _builder.CreateDataRecordExpression<TResult>();
            return _cache.CreateFunc(exp);
        }
    }
}
