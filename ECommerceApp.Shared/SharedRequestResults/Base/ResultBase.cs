namespace ECommerceApp.Shared.SharedRequestResults.Base
{
    public abstract class ResultBase
    {
        public bool Succeeded { get;  set; } = false;
        public string Message { get;  set; } = string.Empty;
    }
}