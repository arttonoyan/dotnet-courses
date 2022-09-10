using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Threading;

namespace _011_Yield_DataRepository
{
    public interface IDataRepository
    {
        IEnumerable<IDataRecord> GetEnumerable(string query);
        IAsyncEnumerable<IDataRecord> GetAsyncEnumerable(string query, CancellationToken cancellationToken = default);
    }

    class DataRepository : IDataRepository
    {
        public DataRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        private readonly string _connectionString;

        public IEnumerable<IDataRecord> GetEnumerable(string query)
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

        public async IAsyncEnumerable<IDataRecord> GetAsyncEnumerable(string query, [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            using var conn = new SqlConnection(_connectionString);
            if (conn.State != ConnectionState.Open)
                await conn.OpenAsync(cancellationToken);

            using var comand = conn.CreateCommand();
            comand.CommandType = CommandType.Text;
            comand.CommandText = query;
            var reader = await comand.ExecuteReaderAsync(cancellationToken);

            while (await reader.ReadAsync(cancellationToken))
                yield return reader;
        }
    }
}
