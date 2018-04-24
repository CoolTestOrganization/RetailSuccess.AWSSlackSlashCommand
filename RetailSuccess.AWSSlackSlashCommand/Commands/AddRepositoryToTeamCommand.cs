using System;
using pb = Paramore.Brighter;

namespace RetailSuccess.GitHub.Commands
{
    public static partial class AddRepositoryToTeam
    {
        public class Command : pb.Command
        {
            public Command(string repositoryName, string organization, string teamName = "Posim") : base(Guid.NewGuid())
            {
                RepositoryName = repositoryName;
                Organization = organization;
                TeamName = teamName;
            }

            public string RepositoryName { get; }
            public string Organization { get; }
            public string TeamName { get; }
        }
    }
}