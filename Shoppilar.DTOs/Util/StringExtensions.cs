using System.Linq.Expressions;
using System.Security.Claims;
using System.Text.Json;
using Remote.Linq;
using Remote.Linq.Text.Json;
using LambdaExpression = Remote.Linq.Expressions.LambdaExpression;

namespace Shoppilar.DTOs.Util;

public static class ExpressionExtensions
{
    public static Expression<Func<T, bool>>? DeserializeLambdaExpression<T>(this string? json)
    {
        if (string.IsNullOrWhiteSpace(json)) return null;
        var serializerOptions = new JsonSerializerOptions().ConfigureRemoteLinq();
        var expression = JsonSerializer.Deserialize<LambdaExpression>(json, serializerOptions);
        var predicate = expression?.ToLinqExpression<T, bool>();
        return predicate;
    }

    private static byte[] ParseBase64WithoutPadding(string base64Url)
    {
        var base64 = base64Url.Replace('-', '+').Replace('_', '/');

        switch (base64.Length % 4)
        {
            case 2: base64 += "=="; break;
            case 3: base64 += "="; break;
        }

        return Convert.FromBase64String(base64);
    }

    public static List<Claim> ParseClaimsFromJwt(this string jwt)
    {
        var claims = new List<Claim>();
        var jwtSplit = jwt.Split('.');
        var payload = jwtSplit.Length > 0 ? jwtSplit[1] : string.Empty;
        var jsonBytes = ParseBase64WithoutPadding(payload);
        var pairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

        if (pairs == null)
            return claims;

        var claimListTypes = new List<string> { ClaimTypes.Role };
        ParseClaims(pairs, claimListTypes, claims);

        claims.AddRange(pairs.Select(pair => new Claim(pair.Key, pair.Value.ToString() ?? string.Empty)));

        return claims;
    }

    private static void ParseClaims(Dictionary<string, object> pairs, List<string> claimListTypes, List<Claim> claims)
    {
        foreach (var type in claimListTypes)
        {
            pairs.TryGetValue(type, out var value);
            ParseClaims(value, type, pairs, claims);
        }
    }

    private static void ParseClaims(object? value, string claimType, Dictionary<string, object> pairs,
        List<Claim> claims)
    {
        if (value == null) return;
        var json = value.ToString()?.Trim() ?? string.Empty;
        if (json.StartsWith('['))
        {
            var parsedPessoas = JsonSerializer.Deserialize<string[]>(json) ?? [];
            claims.AddRange(parsedPessoas.Select(parsedPessoa => new Claim(claimType, parsedPessoa)));
        }
        else
            claims.Add(new Claim(claimType, json));

        pairs.Remove(claimType);
    }
}