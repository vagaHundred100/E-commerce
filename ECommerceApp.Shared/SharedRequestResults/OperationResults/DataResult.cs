using ECommerceApp.Shared.SharedRequestResults.SharedConstants;
using System.Collections;

namespace ECommerceApp.Shared.SharedRequestResults.Base
{
    public sealed class DataResult<T> : ResultBase
    {
        public T? Data { get; }
        public DataResult(T? data)
        {
            if (data is null)
            {
                Succeeded = false;
                Message = RequestResults.DataNotFound;
            }
            else if (data is ICollection collection)
            {
                if (collection.Count > 0)
                {
                    Succeeded = true;
                    Message = RequestResults.Successful;
                    Data = data;
                }
                else
                {
                    Succeeded = false;
                    Message = RequestResults.DataNotFound;
                }
            }
            else if (data is not null)
            {
                Succeeded = true;
                Message = RequestResults.Successful;
                Data = data;
            }
        }
    }
}