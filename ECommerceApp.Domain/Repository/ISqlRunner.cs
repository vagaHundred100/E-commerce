using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceApp.Domain.Repository
{
    public interface ISqlRunner
    {
        Task<List<T>> GetModelListFromNativeSQLAsync<T>(string sqlQuery);
        List<T> GetModelListFromNativeSQL<T>(string sqlQuery);
        Task<T> GetModelFromNativeSQLAsync<T>(string sqlQuery);
        IQueryable<T> GetModelListFromNativeSQLIQueryable<T>(string sqlQuery);
        IQueryable<T> GetModelListFromNativeSQLIQueryableWithParam<T>(string sqlQuery, object Params);
        T GetModelFromNativeSQL<T>(string sqlQuery);
        T GetModelFromNativeSQLWithParam<T>(string sqlQuery, object Params);
        Task<T> GetModelFromNativeSQLWithParamAsync<T>(string sqlQuery, object Params);
        Task ExecuteNativeSqlAsync(string sqlQuery);
        Task ExecuteNativeSqlWithParamsAsync(string sqlQuery, object Params);
        void ExecuteNativeSql(string sqlQuery);
        void ExecuteNativeSqlWithParam(string sqlQuery, object Params);
    }
}