using System;
using System.Data.Common;
using System.IO;

namespace _016_Exceptions
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class MyDataReader : TextReader
    {
        private readonly DbConnection _connection;

        public MyDataReader(DbConnection connection)
        {
            _connection = connection;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (_connection != null)
                _connection.Dispose();
        }
    }
}
