using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Configuration;
using Shoppilar.DTOs.App.Response;
using Shoppilar.DTOs.Ext;
using Shoppilar.DTOs.Util;
using Shoppilar.Interfaces.Ext;

namespace Shoppilar.Services.Ext;

public class SmsService : ISmsService
{
    private readonly HttpClient _httpClient;
    private readonly string _sender;

    public SmsService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;

        var baseUrl = configuration["Sms:BaseUrl"] ?? throw new ArgumentNullException(nameof(httpClient));
        var authKey = configuration["Sms:AuthKey"] ?? throw new ArgumentNullException(nameof(httpClient));
        _sender = configuration["Sms:Sender"] ?? "Shoppilar";

        _httpClient.BaseAddress = new Uri(baseUrl);
        _httpClient.DefaultRequestHeaders.Clear();
        _httpClient.DefaultRequestHeaders.Add("auth-key", authKey);
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        _httpClient.Timeout = TimeSpan.FromSeconds(10);
    }

    public async Task<BaseResponse> SendAsync(SmsInput smsInput, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(smsInput.Celular))
            return new BaseResponse(false, "Número de celular inválido.");

        var normalizedPhone = NormalizePhoneNumber(smsInput.Celular);

        var payload = new
        {
            Sender = _sender,
            Receivers = normalizedPhone,
            Content = smsInput.Mensagem
        };

        using var jsonContent = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");

        try
        {
            using var response = await _httpClient.PostAsync("send", jsonContent, cancellationToken);
            var responseString = await response.Content.ReadAsStringAsync(cancellationToken);

            return response.IsSuccessStatusCode
                ? new BaseResponse(true, "SMS enviado com sucesso.")
                : new BaseResponse(false, $"Erro ao enviar SMS: {responseString}");
        }
        catch (TaskCanceledException ex) when (!cancellationToken.IsCancellationRequested)
        {
            return new BaseResponse(false, $"Timeout ao enviar SMS: {ex.Message}");
        }
        catch (Exception ex)
        {
            return new BaseResponse(false, $"Erro inesperado: {ex.Message}");
        }
    }

    private static string NormalizePhoneNumber(string phone)
        => Regex.Replace(phone, "[^0-9]", "");
}