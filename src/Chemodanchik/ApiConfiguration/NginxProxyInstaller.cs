using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpOverrides;

namespace Chemodanchik.ApiConfiguration;

public static class NginxProxyInstaller
{
    /// <summary>
    /// Configures forwarded headers for nginx as stated here at
    /// <a href="https://learn.microsoft.com/en-us/aspnet/core/host-and-deploy/linux-nginx"> Microsoft Learn</a>
    /// </summary>
    /// <param name="app">A <see cref="WebApplication"/> instance</param>
    public static void ConfigureForwardedHeaders(this WebApplication app)
    {
        app.UseForwardedHeaders(
            new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            }
        );
    }
}
