using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace _011_Yield_DataRepository
{
    public interface IDataRepository
    {
        IEnumerable<IDataRecord> GetExecuter(string query);
    }

    class DataRepository : IDataRepository
    {
        public DataRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        private readonly string _connectionString;

        public IEnumerable<IDataRecord> GetExecuter(string query)
        {
            using var conn = new SqlConnection(_connectionString);
            if (conn.State != ConnectionState.Open)
                conn.Open();

            using var comand = conn.CreateCommand();
            comand.CommandType = CommandType.Text;
            comand.CommandText = query;
            var reader = comand.ExecuteReader();

            while (reader.Read())
                yield return reader;
        }
    }
}
