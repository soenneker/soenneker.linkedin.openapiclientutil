using Soenneker.LinkedIn.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.LinkedIn.OpenApiClientUtil.Abstract;

/// <summary>
/// Exposes a cached OpenAPI client instance.
/// </summary>
public interface ILinkedInOpenApiClientUtil: IDisposable, IAsyncDisposable
{
    ValueTask<LinkedInOpenApiClient> Get(CancellationToken cancellationToken = default);
}
