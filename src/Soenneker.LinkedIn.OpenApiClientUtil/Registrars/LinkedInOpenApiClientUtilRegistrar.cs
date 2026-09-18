using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.LinkedIn.HttpClients.Registrars;
using Soenneker.LinkedIn.OpenApiClientUtil.Abstract;

namespace Soenneker.LinkedIn.OpenApiClientUtil.Registrars;

/// <summary>
/// Registers the OpenAPI client utility for dependency injection.
/// </summary>
public static class LinkedInOpenApiClientUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="LinkedInOpenApiClientUtil"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddLinkedInOpenApiClientUtilAsSingleton(this IServiceCollection services)
    {
        services.AddLinkedInOpenApiHttpClientAsSingleton()
                .TryAddSingleton<ILinkedInOpenApiClientUtil, LinkedInOpenApiClientUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="LinkedInOpenApiClientUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddLinkedInOpenApiClientUtilAsScoped(this IServiceCollection services)
    {
        services.AddLinkedInOpenApiHttpClientAsSingleton()
                .TryAddScoped<ILinkedInOpenApiClientUtil, LinkedInOpenApiClientUtil>();

        return services;
    }
}
