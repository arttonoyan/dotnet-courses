using System;
using System.Data;
using System.Linq;

namespace _011_Yield_DataRepository
{
    class Program
    {
        static void Main(string[] args)
        {
            IDataRepository repo = new DataRepository(Settings.ConnectionString);
            var mapper = GetStudentMapper();
            var res = repo
                .GetExecuter("select * from Student", mapper)
                .GroupBy(p => p.Age)
                .ToDictionary(p => p.Key, p => p.ToList());
        }

        static Func<IDataRecord, Student> GetStudentMapper() =>
            reader => new Student
            {
                Id = (int)reader["Id"],
                Name = (string)reader["Name"],
                Surname = (string)reader["Surname"],
                Age = (int)reader["Age"]
            };
    }

    public static class Settings
    {
        public const string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=UniversityDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
    }

    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
    }
}
