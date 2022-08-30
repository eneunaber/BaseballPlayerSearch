using LaunchDarkly.Sdk;
using LaunchDarkly.Sdk.Server;

namespace BaseballPlayerSearch.Services
{
    public class LaunchDarklyService : ILaunchDarklyService
    {
        public LdClient GetLdClient()
        {
            var ldConfig = Configuration.Default("Change-me");

            return new LdClient(ldConfig);
        }

        public User GetLdUser()
        {
            return User.Builder("baseball-player-search-user-key")
                            .Name("demo-user")
                            .Build();
        }
    }
}