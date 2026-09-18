using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Extensions.Configuration;
using Soenneker.Extensions.ValueTask;
using Soenneker.LinkedIn.HttpClients.Abstract;
using Soenneker.LinkedIn.OpenApiClientUtil.Abstract;
using Soenneker.LinkedIn.OpenApiClient;
using Soenneker.Kiota.GenericAuthenticationProvider;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.LinkedIn.OpenApiClientUtil;

///<inheritdoc cref="ILinkedInOpenApiClientUtil"/>
public sealed class LinkedInOpenApiClientUtil : ILinkedInOpenApiClientUtil
{
    private readonly AsyncSingleton<LinkedInOpenApiClient> _client;

    public LinkedInOpenApiClientUtil(ILinkedInOpenApiHttpClient httpClientUtil, IConfiguration configuration)
    {
        _client = new AsyncSingleton<LinkedInOpenApiClient>(async token =>
        {
            HttpClient httpClient = await httpClientUtil.Get(token).NoSync();

            var apiKey = configuration.GetValueStrict<string>("LinkedIn:AccessToken");
            string authHeaderName = configuration["LinkedIn:AuthHeaderName"] ?? "Authorization";
            string authHeaderValueTemplate = configuration["LinkedIn:AuthHeaderValueTemplate"] ?? "Bearer {token}";
            string authHeaderValue = authHeaderValueTemplate.Replace("{token}", apiKey, StringComparison.Ordinal);

            var requestAdapter = new HttpClientRequestAdapter(new GenericAuthenticationProvider(headerName: authHeaderName, headerValue: authHeaderValue),
                httpClient: httpClient);

            return new LinkedInOpenApiClient(requestAdapter);
        });
    }

    public ValueTask<LinkedInOpenApiClient> Get(CancellationToken cancellationToken = default)
    {
        return _client.Get(cancellationToken);
    }

    public void Dispose()
    {
        _client.Dispose();
    }

    public ValueTask DisposeAsync()
    {
        return _client.DisposeAsync();
    }
}
