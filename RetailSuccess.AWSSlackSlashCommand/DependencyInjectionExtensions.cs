using System;
using Microsoft.Extensions.DependencyInjection;
using RetailSuccess.DependencyInjection;
using RetailSuccess.GitHub.Commands;
using RetailSuccess.GitHub.Queries;
using RetailSuccess.Paramore.Brighter.DependencyInjection;
using RetailSuccess.Paramore.Darker.DependencyInjection;

namespace RetailSuccess.GitHub.DependencyInjection
{
    public static class DependencyInjection
    {
        public static void AddGitHub(this IServiceCollection services, Action<GitHubClientOptions> gitHubClientOptions)
        {
            var darkBuilder = services.AddDarker();
            var brightBuilder = services.AddBrighter();
            services = new ParamoreServiceCollection(services, darkBuilder, brightBuilder);
            services.GetDarker()
                .AddHandlers(typeof(GetRepositoryByName).Assembly);
            services.GetBrighter()
                .AddHandlers(typeof(CreateBranch).Assembly)
                .AddAsyncHandlers(typeof(CreateBranch).Assembly);
            services.AddSingleton<GitProcessor>();
            services.AddSingleton(provider =>
            {
                var options = new GitHubClientOptions();
                gitHubClientOptions?.Invoke(options);
                return options;
            });
        }
    }
}