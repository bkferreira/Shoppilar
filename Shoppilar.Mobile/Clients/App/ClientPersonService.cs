using System.Linq.Expressions;
using System.Net;
using System.Net.Http.Json;
using Shoppilar.Data.App.Models;
using Shoppilar.DTOs.App.Input;
using Shoppilar.DTOs.App.Response;
using Shoppilar.DTOs.Util;
using Shoppilar.Interfaces.App;

namespace Shoppilar.Mobile.Clients.App;

public class ClientPersonService(IHttpClientFactory httpClientFactory)
    : BaseClientService(httpClientFactory), IPersonService
{
    public async Task<PersonResponse?> GetAsync(
        Expression<Func<Person, bool>> predicate,
        string? includeProperties,
        CancellationToken cancellationToken = default)
    {
        var json = JsonContent.Create(new GetAllRequest(predicate.Serialize(), includeProperties));
        var response = await HttpClient.PostAsync(Routes.PersonGetAsync, json, cancellationToken);

        if (!response.IsSuccessStatusCode)
            return null;

        if (response.StatusCode == HttpStatusCode.NoContent)
            return null;

        var result = await response.Content.ReadFromJsonAsync<BaseResponse<PersonResponse>>(cancellationToken);

        if (result!.Success) return result.Item;
        else return null;
    }

    public async Task<List<PersonResponse>> GetAllAsync(
        Expression<Func<Person, bool>>? predicate = null,
        string? includeProperties = null,
        CancellationToken cancellationToken = default)
    {
        var req = new GetAllRequest(predicate?.Serialize() ?? string.Empty, includeProperties);
        var json = JsonContent.Create(req);

        var response = await HttpClient.PostAsync(Routes.PersonGetAllAsync, json, cancellationToken);
        if (!response.IsSuccessStatusCode) return [];

        var result = await response.Content.ReadFromJsonAsync<BaseResponse<List<PersonResponse>>>(cancellationToken);

        if (result!.Success) return result.Item ?? [];
        else return [];
    }

    public async Task<PaginatedResponse<PersonResponse>> GetPagedAsync(
        Expression<Func<Person, bool>>? predicate = null,
        int page = 1,
        int pageSize = 10,
        CancellationToken cancellationToken = default)
    {
        var req = new GetPagedRequest
        {
            Expression = predicate?.Serialize() ?? string.Empty,
            Page = page,
            PageSize = pageSize
        };

        var json = JsonContent.Create(req);
        var response = await HttpClient.PostAsync(Routes.PersonGetPagedAsync, json, cancellationToken);
        if (!response.IsSuccessStatusCode)
            return new PaginatedResponse<PersonResponse>();

        var result =
            await response.Content
                .ReadFromJsonAsync<BaseResponse<PaginatedResponse<PersonResponse>>>(cancellationToken);
        return result?.Item ?? new PaginatedResponse<PersonResponse>();
    }

    public async Task<PersonResponse?> InsertAsync(
        PersonInput input,
        CancellationToken cancellationToken = default)
    {
        var content = JsonContent.Create(input);
        var response = await HttpClient.PostAsync(Routes.PersonInsertAsync, content, cancellationToken);
        if (!response.IsSuccessStatusCode)
            return null;

        var result = await response.Content.ReadFromJsonAsync<BaseResponse<PersonResponse?>>(cancellationToken);

        if (result!.Success) return result.Item;
        else return null;
    }

    public async Task<PersonResponse?> UpdateAsync(
        PersonInput input,
        CancellationToken cancellationToken = default)
    {
        var content = JsonContent.Create(input);
        var response = await HttpClient.PutAsync(Routes.PersonUpdateAsync, content, cancellationToken);
        if (!response.IsSuccessStatusCode)
            return null;

        var result = await response.Content.ReadFromJsonAsync<BaseResponse<PersonResponse?>>(cancellationToken);

        if (result!.Success) return result.Item;
        else return null;
    }

    public async Task<bool> DeleteAsync(PersonInput input, CancellationToken cancellationToken = default)
    {
        if (input.Id == Guid.Empty)
            return false;

        var response = await HttpClient.DeleteAsync($"{Routes.PersonDeleteAsync}/{input.Id}", cancellationToken);

        if (!response.IsSuccessStatusCode)
            return false;

        var result = await response.Content.ReadFromJsonAsync<BaseResponse<bool?>>(cancellationToken);

        if (result!.Success) return result.Item ?? false;
        else return false;
    }

    public async Task<int> CountAsync(
        Expression<Func<Person, bool>>? predicate = null,
        CancellationToken cancellationToken = default)
    {
        var req = new GetAllRequest(predicate?.Serialize() ?? string.Empty);
        var json = JsonContent.Create(req);

        var response = await HttpClient.PostAsync(Routes.PersonCountAsync, json, cancellationToken);
        if (!response.IsSuccessStatusCode)
            return 0;

        var result = await response.Content.ReadFromJsonAsync<BaseResponse<int>>(cancellationToken);
        return result!.Item;
    }
}