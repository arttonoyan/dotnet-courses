using System.Data;

namespace _011_Yield_DataRepository
{
    public static class DataMapper
    {
        public static Student ToStudent(IDataRecord reader)
        {
            return new Student
            {
                Id = (int)reader["Id"],
                Name = (string)reader["Name"],
                Surname = (string)reader["Surname"],
                Age = (int)reader["Age"]
            };
        }
    }
}
