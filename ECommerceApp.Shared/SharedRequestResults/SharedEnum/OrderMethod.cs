using System.ComponentModel;

namespace ECommerceApp.Shared.SharedRequestResults.SharedEnum
{
    public enum OrderMethod
    {
        [Description("OrderBy")]
        ASC = 1,
        [Description("OrderByDescending")]
        DESC = 2,
    }
}