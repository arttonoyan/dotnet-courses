using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace _009_Expressions
{
    public interface IMapperBuilder
    {
        Expression<Func<IDataRecord, TResult>> CreateDataRecordExpression<TResult>()
            where TResult : class, new();
    }

    public class MapperBuilder : IMapperBuilder
    {
        public Expression<Func<IDataRecord, TResult>> CreateDataRecordExpression<TResult>()
            where TResult : class, new()
        {
            Type resultType = typeof(TResult);

            Dictionary<string, PropertyInfo> members = resultType
                .GetProperties()
                .ToDictionary(p => p.Name, p => p);

            var miIndexator = typeof(IDataRecord).GetProperties()
                .First(p => p.GetIndexParameters()
                    .Any(p1 => p1.ParameterType == typeof(string)))
                    .GetMethod;

            var par = Expression.Parameter(typeof(IDataRecord), "<r>");

            var memberAssignments = new List<MemberAssignment>(members.Count);
            Type stringType = typeof(string);
            foreach (var item in members)
            {
                var indexatorMemberExp = Expression.Call(par, miIndexator, Expression.Constant(item.Key, stringType));
                var dbNullCheckExp = Expression.Call(typeof(Check).GetMethod(nameof(Check.ConvertDbNull)), indexatorMemberExp);
                var memberCastExp = Expression.Convert(dbNullCheckExp, item.Value.PropertyType);
                MemberAssignment memberAssignmentExp = Expression.Bind(members[item.Key], memberCastExp);
                memberAssignments.Add(memberAssignmentExp);
            }

            NewExpression model = Expression.New(resultType);
            MemberInitExpression body = Expression.MemberInit(model, memberAssignments);

            return Expression.Lambda<Func<IDataRecord, TResult>>(body, par);
        }

        private static class Check
        {
            public static object ConvertDbNull(object obj)
            {
                if (obj is DBNull)
                    return "";
                return obj;
            }
        }
    }
}
