namespace Shoppilar.DTOs.Util
{
    public class BaseResponse(bool success, string? message = null)
    {
        public bool Success { get; set; } = success;
        public string? Message { get; set; } = message;
    }

    public class BaseResponse<T>(bool success, string? message = null, T? item = default)
        : BaseResponse(success, message)
    {
        public T? Item { get; set; } = item;
    }
}