using System.Linq.Expressions;
using ECommerceApp.Shared.SharedRequestResults.Base;
using System.Linq;
using System;
using System.Linq.Dynamic.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerceApp.Shared.SharedRequestResults.SharedEnum;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApp.Shared.SharedRequestResults.SharedExtensions
{
    public static class QueryableExtension
    {
        /// <summary>
        /// Data WithPagination
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="expression"></param>
        /// <param name="paginationSettings"></param>
        /// <returns>
        ///  If PaginationFilter null returns dafult Pagination data
        /// 
        /// </returns>
        public static PagedDataResult<List<T>> WithOrderedPagination<T>(this IQueryable<T> source, Expression<Func<T, bool>> expression, PaginationSettings paginationSettings = null)
        {
            if (paginationSettings == null)
            {
                paginationSettings = new PaginationSettings();
            }
            int TotalItemsCount = source.Count();
            IQueryable<T> items = source.Where(expression).OrderByField(paginationSettings.SortField, paginationSettings.OrderMethod)
                .Skip((paginationSettings.PageNumber - 1) * paginationSettings.PageSize)
                .Take(paginationSettings.PageSize);
            return new PagedDataResult<List<T>>(items.ToList(), paginationSettings.PageNumber, paginationSettings.PageSize, TotalItemsCount);
        }

        /// <summary>
        /// Data WithPagination
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="paginationSettings"></param>
        /// <returns>
        ///  If PaginationFilter null returns dafult Pagination data
        /// </returns>
        public static PagedDataResult<List<T>> WithOrderedPagination<T>(this IQueryable<T> source, PaginationSettings paginationSettings = null)
        {
            if (paginationSettings == null)
            {
                paginationSettings = new PaginationSettings();
            }
            int TotalItemsCount = source.Count();
            IQueryable<T> items = source.OrderByField(paginationSettings.SortField, paginationSettings.OrderMethod)
                .Skip((paginationSettings.PageNumber - 1) * paginationSettings.PageSize)
                .Take(paginationSettings.PageSize);
            return new PagedDataResult<List<T>>(items.ToList(), paginationSettings.PageNumber, paginationSettings.PageSize, TotalItemsCount);
        }

        /// <summary>
        /// Data WithPaginationAsync
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="paginationSettings"></param>
        /// <returns>
        ///  If PaginationFilter null returns dafult Pagination data
        /// </returns>
        public static async Task<PagedDataResult<List<T>>> WithOrderedPaginationAsync<T>(this IQueryable<T> source, PaginationSettings paginationSettings = null)
        {
            if (paginationSettings == null)
            {
                paginationSettings = new PaginationSettings();
            }
            int TotalItemsCount = source.Count();
            List<T> items = await source.OrderByField(paginationSettings.SortField, paginationSettings.OrderMethod)
                .Skip((paginationSettings.PageNumber - 1) * paginationSettings.PageSize)
                .Take(paginationSettings.PageSize).ToListAsync();
            return new PagedDataResult<List<T>>(items.ToList(), paginationSettings.PageNumber, paginationSettings.PageSize, TotalItemsCount);
        }
        public static IQueryable<T> OrderByFielde<T>(this IQueryable<T> query, string SortField, OrderMethod OrderMethod)
        {
            if (string.IsNullOrWhiteSpace(SortField))
            {
                SortField = "ID";
            }
            ParameterExpression param = Expression.Parameter(typeof(T), "paramForOrder");
            MemberExpression prop = Expression.Property(param, SortField.Trim()); // paramForOrder.Number  edir
            LambdaExpression exp = Expression.Lambda(prop, param); // p=>p.SortField edir
            Type[] types = new Type[] { query.ElementType, exp.Body.Type };
            MethodCallExpression mce = Expression.Call(typeof(Queryable), OrderMethod.ToString(), types, query.Expression, exp);
            return query.Provider.CreateQuery<T>(mce);
        }
        public static IQueryable<T> OrderByField<T>(this IQueryable<T> query, string SortField, OrderMethod OrderMethod)
        {
            if (string.IsNullOrWhiteSpace(SortField))
            {
                SortField = "ID";
            }
            string dynamicLINQquery = $"{SortField} {OrderMethod}";
            return query.OrderBy(dynamicLINQquery);
        }
    }
}