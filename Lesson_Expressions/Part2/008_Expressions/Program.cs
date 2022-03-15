using _000_DataAccess;
using _000_DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace _008_Expressions
{
    class Program
    {
        static void Main(string[] args)
        {
            Expression<Func<IDataRecord, Blog>> convertExp = CreateDataRecordConverterExpression<Blog>();
            Func<IDataRecord, Blog> convert = convertExp.Compile();

            var repo = new DataRepository(Connection.Default);

            var blogs = new List<Blog>();
            foreach (Blog blog in repo.Execute("select * from Blogs", convert))
            {
                blogs.Add(blog);
            }

            Console.ReadLine();
        }

        static Expression<Func<IDataRecord, TModel>> CreateDataRecordConverterExpression<TModel>()
            where TModel : class, new()
        {
            Type destType = typeof(TModel);

            Dictionary<string, PropertyInfo> members = destType
                .GetProperties()
                .ToDictionary(p => p.Name, p => p);

            var indexatorMethod = typeof(IDataRecord).GetProperties()
                .First(p => p.GetIndexParameters()
                    .Any(p1 => p1.ParameterType == typeof(string)))
                    .GetMethod;

            var par = Expression.Parameter(typeof(IDataRecord), "<r>");

            var memberAssignments = new List<MemberAssignment>(members.Count);
            Type stringType = typeof(string);
            foreach (var item in members)
            {
                var indexatorMemberExp = Expression.Call(par, indexatorMethod, Expression.Constant(item.Key, stringType));
                var memberCastExp = Expression.Convert(indexatorMemberExp, item.Value.PropertyType);
                MemberAssignment memberAssignmentExp = Expression.Bind(members[item.Key], memberCastExp);
                memberAssignments.Add(memberAssignmentExp);
            }

            NewExpression model = Expression.New(destType);
            MemberInitExpression body = Expression.MemberInit(model, memberAssignments);

            return Expression.Lambda<Func<IDataRecord, TModel>>(body, par);
        }
    }
}
