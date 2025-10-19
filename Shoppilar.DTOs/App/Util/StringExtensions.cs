using System.Linq.Expressions;
using System.Text.Json;
using Remote.Linq;
using Remote.Linq.Text.Json;
using LambdaExpression = Remote.Linq.Expressions.LambdaExpression;

namespace Shoppilar.DTOs.App.Util;

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
}