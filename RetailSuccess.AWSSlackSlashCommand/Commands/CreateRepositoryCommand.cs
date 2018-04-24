using System;
using pb = Paramore.Brighter;

namespace RetailSuccess.GitHub.Commands
{
    public static partial class CreateRepository
    {
        public class Command : pb.Command
        {
            public Command(string repositoryName, string organization = "Retail-Success") : base(Guid.NewGuid())
            {
                RepositoryName = repositoryName;
                Organization = organization;
            }

            public string RepositoryName { get; }
            public string Organization { get; }
        }
    }
}