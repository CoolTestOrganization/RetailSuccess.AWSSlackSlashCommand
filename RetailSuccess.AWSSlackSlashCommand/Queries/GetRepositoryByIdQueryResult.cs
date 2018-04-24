using Octokit;

namespace RetailSuccess.GitHub.Queries
{
    public static partial class GetRepositoryById
    {
        public class QueryResult
        {
            public Repository Repository { get; set; }
        }
    }
}