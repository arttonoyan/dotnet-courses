using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace _011_Yield_DataRepository
{
    class Program
    {
        static void Main(string[] args)
        {
            string connString = "...";
            IDataRepository repo = new DataRepository("connString");

            Func<IDataRecord, SomeClass> mapper = GetSomeClassMapper();
            List<SomeClass> res = repo
                .ExecuteAsEnumerable("select * from [Table] where .....", mapper)
                .ToList();
        }

        static Func<IDataRecord, SomeClass> GetSomeClassMapper()
        {
            return reader => new SomeClass();
        }
    }

    class SomeClass { }
}
