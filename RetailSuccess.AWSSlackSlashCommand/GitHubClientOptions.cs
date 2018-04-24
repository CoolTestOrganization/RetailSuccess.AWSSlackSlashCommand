using System;
using Octokit;

namespace RetailSuccess.GitHub
{
    public sealed class GitHubClientOptions
    {
        public Func<GitHubClient> GitHubClientFactory { get; set; }
        public string OrganizationName { get; set; }
        public string DefaultTeamName { get; set; }
        public string UserName { get; set; }
    }
}