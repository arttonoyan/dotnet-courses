using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace _011_Yield_DataRepository
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IDataRepository repo = new DataRepository(Settings.ConnectionString);

            var students = repo.GetStudents().ToList();

            await foreach (var item in repo.GetAsyncEnumerable("select * from Student"))
            {

            }

            var en = repo
                .GetAsyncEnumerable("select * from Student")
                .GetAsyncEnumerator();

            while (await en.MoveNextAsync())
            {
                var item = en.Current;
            }

            Console.ReadLine();
        }
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
