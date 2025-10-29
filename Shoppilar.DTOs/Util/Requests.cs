namespace Shoppilar.DTOs.Util;

public class GetWithExpression
{
    public string? Expression { get; set; }
}

public class GetAllRequest : GetWithExpression
{
    public string? IncludeProperties { get; set; }
    
    public GetAllRequest(string? expression, string? includeProperties = null)
    {
        Expression = expression;
        IncludeProperties = includeProperties;
    }
}

public class GetPagedRequest : GetWithExpression
{
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}

public class CountRequest
{
    public string? Expression { get; set; }
}