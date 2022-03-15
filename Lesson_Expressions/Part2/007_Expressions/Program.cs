using _000_DataAccess;
using _000_DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace _007_Expressions
{
    class Program
    {
        static void Main(string[] args)
        {
            Expression<Func<IDataRecord, Blog>> convertExp = CreateLabdaExpression();
            Func<IDataRecord, Blog> convert = convertExp.Compile();

            var repo = new DataRepository(Connection.Default);

            var blogs = new List<Blog>();
            foreach (Blog blog in repo.Execute("select * from Blogs", convert))
            {
                blogs.Add(blog);
            }

            Console.ReadLine();
        }

        static Expression<Func<IDataRecord, Blog>> CreateLabdaExpression()
        {
            Type destType = typeof(Blog);

            Dictionary<string, PropertyInfo> members = destType
                .GetProperties()
                .ToDictionary(p => p.Name, p => p);

            var indexatorMethod = typeof(IDataRecord).GetProperties()
                .First(p => p.GetIndexParameters()
                    .Any(p1 => p1.ParameterType == typeof(string)))
                    .GetMethod;

            var par = Expression.Parameter(typeof(IDataRecord), "<r>");

            Type stringType = typeof(string);
            var indexatorBlogIdExp = 
                Expression.Call(par, indexatorMethod, Expression.Constant(nameof(Blog.BlogId), stringType));
            var indexatorUrlExp = Expression.Call(par, indexatorMethod, Expression.Constant(nameof(Blog.Url), stringType));

            var memberBlogIdExp = Expression.Convert(indexatorBlogIdExp, typeof(int));
            var memberUrlExp = Expression.Convert(indexatorUrlExp, stringType);

            MemberAssignment maBlogIdExp = Expression.Bind(members[nameof(Blog.BlogId)], memberBlogIdExp);
            MemberAssignment maUrlExp = Expression.Bind(members[nameof(Blog.Url)], memberUrlExp);

            NewExpression model = Expression.New(destType);
            MemberInitExpression body = Expression.MemberInit(model, maBlogIdExp, maUrlExp);

            return Expression.Lambda<Func<IDataRecord, Blog>>(body, par);
        }
    }
}
