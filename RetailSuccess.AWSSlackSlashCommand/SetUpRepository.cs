using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Octokit;
using RetailSuccess.GitHub.DependencyInjection;

namespace RetailSuccess.GitHub
{
    public class SetUpRepository
    {
        public static async Task Run(string repositoryName, string organizationName = "Retail-Success",
            string teamName = "Posim")
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddGitHub(options =>
                {
                    options.OrganizationName = organizationName;
                    options.DefaultTeamName = teamName;
                    var credential = new Credentials(GitCredentials.UserName, GitCredentials.Password);
                    options.UserName = credential.Login;
                    options.GitHubClientFactory = () =>
                    {
                        var gitHubClient = new GitHubClient(new ProductHeaderValue(credential.Login));
                        gitHubClient.Credentials = credential;

                        return gitHubClient;
                    };
                }
            );
            var serviceProvider = serviceCollection.BuildServiceProvider();

            var gitClient = serviceProvider.GetService<GitProcessor>();
            await gitClient.CreateAndSetUpRepository(repositoryName);
        }
    }
}