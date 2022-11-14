using ECommerceApp.Shared.SharedRequestResults.SharedConstants;
using System.Collections;

namespace ECommerceApp.Shared.SharedRequestResults.Base
{
    public sealed class PagedDataResult<T> : ResultBase
    {
        public T? Data { get; }
        public int PageNumber { get; } = 0;
        public int PageSize { get; } = 0;
        public int TotalItemsCount { get; } = 0;

        public PagedDataResult(T data, int pageNumber, int pageSize, int totalItemsCount)
        {
            if (data is null || data is not ICollection)
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
                    PageNumber = pageNumber;
                    PageSize = pageSize;
                    TotalItemsCount = totalItemsCount;
                }
                else
                {
                    Succeeded = false;
                    Message = RequestResults.DataNotFound;
                }
            }
        }
    }
}