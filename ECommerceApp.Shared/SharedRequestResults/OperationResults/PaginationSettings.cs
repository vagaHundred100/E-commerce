using ECommerceApp.Shared.SharedRequestResults.SharedEnum;

namespace ECommerceApp.Shared.SharedRequestResults.Base
{
    public class PaginationSettings
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public OrderMethod OrderMethod { get; set; }
        public string SortField { get; set; }
        public PaginationSettings()
        {
            PageNumber = 1;
            PageSize = 5;
            OrderMethod = OrderMethod.ASC;
            SortField = "ID";
        }
        public PaginationSettings(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber < 1 ? 1 : pageNumber;
            PageSize = pageSize < 5 ? 5 : pageSize;
            OrderMethod = OrderMethod.ASC;
            SortField = "ID";
        }
    }
}