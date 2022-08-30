using LaunchDarkly.Sdk;
using LaunchDarkly.Sdk.Server;

namespace BaseballPlayerSearch.Services
{
    public interface ILaunchDarklyService
    {
        LdClient GetLdClient();
        User GetLdUser();
    }
}