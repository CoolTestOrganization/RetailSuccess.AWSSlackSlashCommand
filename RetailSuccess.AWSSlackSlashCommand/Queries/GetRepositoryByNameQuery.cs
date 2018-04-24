using Paramore.Darker;

namespace RetailSuccess.GitHub.Queries
{
    public static partial class GetRepositoryByName
    {
        public class Query : IQuery<QueryResult>
        {
            public Query(string owner, string repositoryName)
            {
                Owner = owner;
                RepositoryName = repositoryName;
            }

            public string Owner { get; }
            public string RepositoryName { get; }
        }
    }
}