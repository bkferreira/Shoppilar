namespace Shoppilar.DTOs.App.Response;

public class PaginatedResponse<T>(List<T> items, int totalItems)
{
    public List<T> Items { get; set; } = items;
    public int TotalItems { get; set; } = totalItems;

    public PaginatedResponse() : this([], 0)
    {
    }
}