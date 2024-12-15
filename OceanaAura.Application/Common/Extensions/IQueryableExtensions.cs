using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Common.Extensions
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> OrderByDynamic<T>(this IQueryable<T> source, string orderByProperty)
        {
            var command = "OrderBy";
            var type = typeof(T);
            var property = type.GetProperty(orderByProperty);
            if (property == null) throw new ArgumentException("Property not found", nameof(orderByProperty));
            var parameter = Expression.Parameter(type, "p");
            var propertyAccess = Expression.MakeMemberAccess(parameter, property);
            var orderByExpression = Expression.Lambda(propertyAccess, parameter);
            var resultExpression = Expression.Call(
                typeof(Queryable),
                command,
                new Type[] { type, property.PropertyType },
                source.Expression,
                Expression.Quote(orderByExpression));
            return source.Provider.CreateQuery<T>(resultExpression);
        }

        public static IQueryable<T> OrderByDescendingDynamic<T>(this IQueryable<T> source, string orderByProperty)
        {
            return source.OrderByDynamic(orderByProperty, descending: true);
        }

        private static IQueryable<T> OrderByDynamic<T>(this IQueryable<T> source, string orderByProperty, bool descending)
        {
            var command = descending ? "OrderByDescending" : "OrderBy";
            return OrderByDynamicInternal(source, orderByProperty, command);
        }

        private static IQueryable<T> OrderByDynamicInternal<T>(IQueryable<T> source, string orderByProperty, string command)
        {
            var type = typeof(T);
            var property = type.GetProperty(orderByProperty);
            if (property == null) throw new ArgumentException("Property not found", nameof(orderByProperty));
            var parameter = Expression.Parameter(type, "p");
            var propertyAccess = Expression.MakeMemberAccess(parameter, property);
            var orderByExpression = Expression.Lambda(propertyAccess, parameter);
            var resultExpression = Expression.Call(
                typeof(Queryable),
                command,
                new Type[] { type, property.PropertyType },
                source.Expression,
                Expression.Quote(orderByExpression));
            return source.Provider.CreateQuery<T>(resultExpression);
        }
    }
}
