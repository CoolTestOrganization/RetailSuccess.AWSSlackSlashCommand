using System.Threading;
using System.Threading.Tasks;
using Octokit;
using Paramore.Darker;

namespace RetailSuccess.GitHub.Queries
{
    public static partial class GetRepositoryById
    {
        public class QueryHandler : QueryHandlerAsync<Query, QueryResult>
        {
            private readonly GitHubClient _client;

            public QueryHandler(GitHubClientOptions options)
            {
                _client = options.GitHubClientFactory();
            }

            public override async Task<QueryResult> ExecuteAsync(Query query,
                CancellationToken cancellationToken = new CancellationToken())
            {
                var repository = await _client.Repository.Get(query.Id);
                return new QueryResult {Repository = repository};
            }
        }
    }
}