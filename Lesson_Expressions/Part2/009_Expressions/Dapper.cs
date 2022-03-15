using _000_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;

namespace _009_Expressions
{
    public static class Dapper
    {
        static Dapper()
        {
            _mapper = new DataMapper(
                new MapperBuilder(), 
                new InMemoryCache());
        }

        private static readonly IDataMapper _mapper;

        public static IEnumerable<TModel> Execute<TModel>(string query) 
            where TModel : class, new()
        {
            Func<IDataRecord, TModel> convert = _mapper.GetOrCreate<TModel>();

            var repo = new DataRepository(Connection.Default);
            foreach (var model in repo.Execute(query, convert))
                yield return model;
        }
    }
}