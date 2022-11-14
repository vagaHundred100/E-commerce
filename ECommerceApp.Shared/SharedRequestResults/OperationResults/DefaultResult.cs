using ECommerceApp.Shared.SharedRequestResults.SharedConstants;

namespace ECommerceApp.Shared.SharedRequestResults.Base
{
    public sealed class DefaultResult : ResultBase
    {
        public DefaultResult(bool succeeded = true)
        {
            if (succeeded)
            {
                Succeeded = succeeded;
                Message = RequestResults.Successful;
            }
            else
            {
                Message = RequestResults.NotSuccessful;
            }
        }
    }
}