namespace ECommerceApp.Shared.SharedRequestResults.Base
{
    public abstract class ResultBase
    {
        public bool Succeeded { get; protected set; } = false;
        public string Message { get; protected set; } = string.Empty;
    }
}