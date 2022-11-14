namespace ECommerceApp.Shared.SharedRequestResults.Base
{
    public sealed class ExceptionResult : ResultBase
    {
        public string Description { get; } = string.Empty;
        public string InnerException { get; } = string.Empty;
        public ExceptionResult(string description, string message, string innerexception)
        {
            Succeeded = false;
            Description= description;
            Message = message;
            InnerException = innerexception;
        }
    }
}