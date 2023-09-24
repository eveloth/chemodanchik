using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace Chemodanchik.Mvc;

public static class MvcOptionsExtensions
{
    /// <summary>
    /// Transforms default CamelCase routes (i.e. /Api/AccessControl)
    /// to slug case, also known as kebab case (i.e. /api/access-control)
    /// </summary>
    /// <param name="options">An instance of <see cref="MvcOptions"/> the method is called on</param>
    public static void UseSlugCaseRoutes(this MvcOptions options)
    {
        options.Conventions.Add(
            new RouteTokenTransformerConvention(new ToSlugCaseTransformerConvention())
        );
    }
}

public class ToSlugCaseTransformerConvention : IOutboundParameterTransformer
{
    private readonly Regex _regex = new("([a-z])([A-Z])");

    public string? TransformOutbound(object? value)
    {
        return value is null ? null : _regex.Replace(value.ToString()!, "$1-$2").ToLower();
    }
}
