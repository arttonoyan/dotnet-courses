using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace _011_Yield_DataRepository
{
    public interface IDataRepository
    {
        IEnumerable<TModel> ExecuteAsEnumerable<TModel>(string query, 
            Func<IDataRecord, TModel> convertFunc) 
            where TModel : class, new();
    }

    class DataRepository : IDataRepository
    {
        public DataRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        private readonly string _connectionString;

        public IEnumerable<TModel> ExecuteAsEnumerable<TModel>(string query, Func<IDataRecord, TModel> mapper)
            where TModel : class, new()
        {
            using var conn = new SqlConnection(_connectionString);
            if (conn.State != ConnectionState.Open)
                conn.Open();

            using var comand = conn.CreateCommand();
            comand.CommandType = CommandType.Text;
            comand.CommandText = query;
            var reader = comand.ExecuteReader();

            while (reader.Read())
                yield return mapper.Invoke(reader);

            //TModel model;
            //while (reader.Read())
            //{
            //    try
            //    {
            //        model = mapper.Invoke(reader);
            //    }
            //    catch (Exception ex)
            //    {
            //        //log
            //        continue;
            //    }

            //    yield return model;
            //}
        }
    }
}
