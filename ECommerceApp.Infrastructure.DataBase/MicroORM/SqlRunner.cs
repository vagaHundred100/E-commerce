using Dapper;
using ECommerceApp.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Infrastructure.DataBase.MicroORM
{
    public class SqlRunner : ISqlRunner
    {
        private readonly string dbConnectionString = string.Empty;
        public SqlRunner()
        {
            dbConnectionString = AppConnectionString.ConnectionString;
        }
        public void ExecuteNativeSql(string sqlQuery)
        {
            using (IDbConnection db = new MySqlConnection(dbConnectionString))
            {
                db.Execute(sqlQuery);
            }
        }
        public void ExecuteNativeSqlWithParam(string sqlQuery, object Params)
        {
            using (IDbConnection db = new MySqlConnection(dbConnectionString))
            {
                db.Execute(sqlQuery, Params);
            }
        }
        public async Task ExecuteNativeSqlAsync(string sqlQuery)
        {
            using (IDbConnection db = new MySqlConnection(dbConnectionString))
            {
                await db.ExecuteAsync(sqlQuery);
            }
        }
        public List<T> GetModelListFromNativeSQL<T>(string sqlQuery)
        {
            using (IDbConnection db = new MySqlConnection(dbConnectionString))
            {
                return (List<T>)db.Query<T>(sqlQuery);
            }
        }
        public async Task<List<T>> GetModelListFromNativeSQLAsync<T>(string sqlQuery)
        {
            using (IDbConnection db = new MySqlConnection(dbConnectionString))
            {
                return (List<T>)await db.QueryAsync<T>(sqlQuery);
            }
        }
        public IQueryable<T> GetModelListFromNativeSQLIQueryable<T>(string sqlQuery)
        {
            using (IDbConnection db = new MySqlConnection(dbConnectionString))
            {
                return db.Query<T>(sqlQuery).AsQueryable();
            }
        }
        public IQueryable<T> GetModelListFromNativeSQLIQueryableWithParam<T>(string sqlQuery, object Params)
        {
            using (IDbConnection db = new MySqlConnection(dbConnectionString))
            {
                return db.Query<T>(sqlQuery, Params).AsQueryable();
            }
        }
        public async Task<T> GetModelFromNativeSQLAsync<T>(string sqlQuery)
        {
            using (IDbConnection db = new MySqlConnection(dbConnectionString))
            {
                return await db.QueryFirstOrDefaultAsync<T>(sqlQuery);
            }
        }
        public T GetModelFromNativeSQL<T>(string sqlQuery)
        {
            using (IDbConnection db = new MySqlConnection(dbConnectionString))
            {
                return db.QueryFirstOrDefault<T>(sqlQuery);
            }
        }
        public T GetModelFromNativeSQLWithParam<T>(string sqlQuery, object Params)
        {
            using (IDbConnection db = new MySqlConnection(dbConnectionString))
            {
                return db.QueryFirstOrDefault<T>(sqlQuery, Params);
            }
        }
        public async Task<T> GetModelFromNativeSQLWithParamAsync<T>(string sqlQuery, object Params)
        {
            using (IDbConnection db = new MySqlConnection(dbConnectionString))
            {
                return await db.QueryFirstOrDefaultAsync<T>(sqlQuery, Params);
            }
        }
        public async Task ExecuteNativeSqlWithParamsAsync(string sqlQuery, object Params)
        {
            using (IDbConnection db = new MySqlConnection(dbConnectionString))
            {
                await db.ExecuteAsync(sqlQuery, Params);
            }
        }
    }
}
