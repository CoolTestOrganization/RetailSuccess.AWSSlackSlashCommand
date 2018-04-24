using Paramore.Darker;

namespace RetailSuccess.GitHub.Queries
{
    public static partial class GetRepositoryById
    {
        public class Query : IQuery<QueryResult>
        {
            public Query(long id)
            {
                Id = id;
            }

            public long Id { get; }
        }
    }
}