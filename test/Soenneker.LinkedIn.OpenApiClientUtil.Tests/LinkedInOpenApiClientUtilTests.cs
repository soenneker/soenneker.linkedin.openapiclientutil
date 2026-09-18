using Soenneker.LinkedIn.OpenApiClientUtil.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.LinkedIn.OpenApiClientUtil.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class LinkedInOpenApiClientUtilTests : HostedUnitTest
{
    private readonly ILinkedInOpenApiClientUtil _openapiclientutil;

    public LinkedInOpenApiClientUtilTests(Host host) : base(host)
    {
        _openapiclientutil = Resolve<ILinkedInOpenApiClientUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
