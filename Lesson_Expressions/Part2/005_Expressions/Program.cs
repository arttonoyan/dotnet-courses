using _000_DataAccess;
using _000_DataAccess.Models;
using System;
using System.Collections.Generic;

namespace _005_Expressions
{
    class Program
    {
        static void Main(string[] args)
        {
            var repo = new DataRepository(Connection.Default);

            var blogs = new List<Blog>();
            foreach (var reader in repo.AsEnumerable("select * from Blogs"))
            {
                var blog = new Blog
                {
                    BlogId = (int)reader[nameof(Blog.BlogId)],
                    Url = (string)reader[nameof(Blog.Url)]
                };

                blogs.Add(blog);
            }

            Console.ReadLine();
        }
    }
}
