namespace Shoppilar.DTOs.App.Util;

public class GetAllRequest
{
    public string? Expression { get; set; }
    public string? IncludeProperties { get; set; }
}

public class GetPagedRequest : GetAllRequest
{
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}

public class CountRequest
{
    public string? Expression { get; set; }
}