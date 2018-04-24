using Octokit;

namespace RetailSuccess.GitHub.Queries
{
    public static partial class GetRepositoryByName
    {
        public class QueryResult
        {
            public Repository Repository { get; set; }
        }
    }
}