using System.Collections.Generic;

namespace OMTechStation.PropertyPublicity.Authentication.External
{
    public interface IExternalAuthConfiguration
    {
        List<ExternalLoginProviderInfo> Providers { get; }
    }
}
