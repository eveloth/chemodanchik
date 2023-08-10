using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace Chemodanchik.Mvc;

public static class MvcOptionsExtesions
{
    public static void UseSlugCaseRoutes(this MvcOptions options)
    {
        options.Conventions.Add(
            new RouteTokenTransformerConvention(new ToSlugCaseTransformerConvention())
        );
    }
}

public partial class ToSlugCaseTransformerConvention : IOutboundParameterTransformer
{
    public string? TransformOutbound(object? value)
    {
        return value is null
            ? null
            : ToSlugCaseTransformerRegex().Replace(value.ToString()!, "$1-$2").ToLower();
    }

    [GeneratedRegex("([a-z])([A-Z])")]
    private static partial Regex ToSlugCaseTransformerRegex();
}
