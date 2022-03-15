using _000_DataAccess;
using _000_DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace _006_Expressions
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<IDataRecord, Blog> convert = r => new Blog
            {
                BlogId = (int)r[nameof(Blog.BlogId)],
                Url = (string)r[nameof(Blog.Url)]
            };

            var repo = new DataRepository(Connection.Default);

            var blogs = new List<Blog>();
            foreach (Blog blog in repo.Execute("select * from Blogs", convert))
            {
                blogs.Add(blog);
            }

            Console.ReadLine();
        }
    }
}
