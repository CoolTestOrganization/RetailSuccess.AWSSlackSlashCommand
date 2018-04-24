using Paramore.Darker;

namespace RetailSuccess.GitHub.Queries
{
    public partial class GetTeamId
    {
        public class Query : IQuery<QueryResult>
        {
            public Query(string organization, string teamName)
            {
                Organization = organization;
                TeamName = teamName;
            }

            public string Organization { get; }
            public string TeamName { get; }
        }
    }
}