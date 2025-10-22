using System.Linq.Expressions;
using System.Text;

namespace Shoppilar.DTOs.Util
{
    public static class IncludeHelper
    {
        public static string GetIncludePaths<T>(params Expression<Func<T, object>>[]? includes)
        {
            if (includes == null || includes.Length == 0)
                return string.Empty;

            var sb = new StringBuilder();

            foreach (var include in includes)
            {
                var path = GetPropertyPath(include.Body);
                if (!string.IsNullOrEmpty(path))
                {
                    if (sb.Length > 0)
                        sb.Append(',');
                    sb.Append(path);
                }
            }

            return sb.ToString();
        }

        private static string GetPropertyPath(Expression expression)
        {
            switch (expression)
            {
                case MemberExpression member:
                {
                    if (member.Expression != null)
                    {
                        var parent = GetPropertyPath(member.Expression);
                        return string.IsNullOrEmpty(parent) ? member.Member.Name : $"{parent}.{member.Member.Name}";
                    }

                    break;
                }

                case UnaryExpression { NodeType: ExpressionType.Convert } unary:
                    return GetPropertyPath(unary.Operand);

                case MethodCallExpression { Method.Name: "Select" } methodCall:
                {
                    if (methodCall.Arguments is [_, LambdaExpression lambda])
                    {
                        var parent = GetPropertyPath(methodCall.Arguments[0]);
                        var child = GetPropertyPath(lambda.Body);
                        return $"{parent}.{child}";
                    }

                    break;
                }
            }

            return string.Empty;
        }
    }
}