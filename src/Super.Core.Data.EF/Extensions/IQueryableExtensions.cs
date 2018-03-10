using Microsoft.EntityFrameworkCore;
using Super.Core.Data.EF.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Super.Core.Data.EF.Extensions
{
    public static class IQueryableExtensions
    {
        private static readonly MethodInfo _OrderByMethod = typeof(Queryable).GetMethods().Where(method => method.Name == "OrderBy").Where(method => method.GetParameters().Length == 2).Single();
        private static readonly MethodInfo _OrderByDescendingMethod = typeof(Queryable).GetMethods().Where(method => method.Name == "OrderByDescending").Where(method => method.GetParameters().Length == 2).Single();

        public static IOrderedQueryable<TSource> OrderByProperty<TSource>(this IQueryable<TSource> source, string propertyExpression, bool @ascending = true)
        {
            var lambda = ExpressionHelper.ParseProperties<TSource>(propertyExpression);
            var orderByMethod = @ascending ? _OrderByMethod : _OrderByDescendingMethod;
            var genericMethod = orderByMethod.MakeGenericMethod(typeof(TSource), lambda.Body.Type);
            var ret = genericMethod.Invoke(null, new object[] {
                source,
                lambda
            });
            return (IOrderedQueryable<TSource>)ret;
        }

        private static readonly MethodInfo _ThenByMethod = typeof(Queryable).GetMethods().Where(method => method.Name == "ThenBy").Where(method => method.GetParameters().Length == 2).Single();
        private static readonly MethodInfo _ThenByDescendingMethod = typeof(Queryable).GetMethods().Where(method => method.Name == "ThenByDescending").Where(method => method.GetParameters().Length == 2).Single();

        public static IOrderedQueryable<TSource> ThenByProperty<TSource>(this IOrderedQueryable<TSource> source, string propertyExpression, bool @ascending = true)
        {
            var lambda = ExpressionHelper.ParseProperties<TSource>(propertyExpression);
            var orderByMethod = @ascending ? _ThenByMethod : _ThenByDescendingMethod;
            var genericMethod = orderByMethod.MakeGenericMethod(new Type[]{
                typeof(TSource),
                lambda.Body.Type
            });
            var ret = genericMethod.Invoke(null, new object[] {
                source,
                lambda
            });
            return (IOrderedQueryable<TSource>)ret;
        }

        public static IOrderedQueryable<T> Order<T, TOrder>(
            this IQueryable<T> query,
            ISortParams sortParams,
            Expression<Func<T, TOrder>> ordersBy,
            SortDirs defaultSortDir = SortDirs.Asc)
        {
            return query.Order(sortParams, new[] { ordersBy }, null, defaultSortDir);
        }

        public static IOrderedQueryable<T> Order<T, TOrder>(
            this IQueryable<T> query,
            ISortParams sortParams,
            IEnumerable<Expression<Func<T, TOrder>>> ordersBy,
            SortDirs[] sortDirs = null,
            SortDirs defaultSortDir = SortDirs.Asc)
        {
            //Choose between defaults and selected orders
            string[] _ordersBy = null;
            SortDirs[] _sortDirs = null;
            if (sortParams != null && sortParams.SortBy != null && sortParams.SortBy.Any())
            {
                _ordersBy = sortParams.SortBy;
                _sortDirs = sortParams.SortDir;
            }
            else
            {
                _ordersBy = ordersBy.Select(o => ExpressionHelper.GetExpressionText(ExpressionHelper.RemoveConvert(o))).ToArray();
                _sortDirs = ordersBy.Select((o, i) => sortDirs != null && sortDirs.Where((x, ix) => i == ix).Any() ? sortDirs.Where((x, ix) => i == ix).FirstOrDefault() : defaultSortDir).ToArray();
            }

            //Apply Orders
            var y = 0;
            foreach (var o in _ordersBy)
            {
                if (y == 0)
                {
                    query = query.OrderByProperty(o, _sortDirs.ElementAt(y) == SortDirs.Asc);
                }
                else
                {
                    query = ((IOrderedQueryable<T>)query).ThenByProperty(o, _sortDirs.ElementAt(y) == SortDirs.Asc);
                }
                y++;
            }

            return (IOrderedQueryable<T>)query;
        }

        public static async Task<PagedCollection<T>> ToPagedCollectionAsync<T>(this IQueryable<T> query, IPageParams pageParams)
        {
            var data = await query
                    .Skip(pageParams.StartIndex)
                    .Take(pageParams.Length)
                    .ToListAsync();

            var count = data.Any() ? await query.CountAsync() : 0;

            return new PagedCollection<T>(data, count, pageParams.GetCurrentPage());
        }

        public static PagedCollection<T> ToPagedCollection<T>(this IQueryable<T> query, IPageParams pageParams)
        {
            var data = query
                    .Skip(pageParams.StartIndex)
                    .Take(pageParams.Length)
                    .ToList();

            var count = data.Any() ? query.Count() : 0;

            return new PagedCollection<T>(data, count, pageParams.GetCurrentPage());
        }
    }
}
