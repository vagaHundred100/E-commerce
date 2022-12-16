using ECommerceApp.Shared.SharedRequestResults.SharedEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ECommerceApp.Shared.HelperExtentionMethods
{
    public static  class OrderByExtentionClass
    {
        public static IEnumerable<TSource> OrderByPropertyName<TSource>(this IEnumerable<TSource> source,
                      string propertyName,OrderMethod ord)
        {
            PropertyInfo prop = typeof(TSource).GetProperty(propertyName);
            if(ord == OrderMethod.DESC)
            {
                return source.OrderByDescending(x => prop.GetValue(x, null));
            }
            else 
            {
                return source.OrderBy(x => prop.GetValue(x, null));
            }
        }
    }
}
