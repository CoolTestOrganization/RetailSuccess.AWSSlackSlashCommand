using System;
using pb = Paramore.Brighter;

namespace RetailSuccess.GitHub.Commands
{
    public static partial class CreateBranch
    {
        public class Command : pb.Command
        {
            public Command(long repository, string originalBranch = "heads/master",
                string newBranch = "refs/heads/develop") : base(Guid.NewGuid())
            {
                RepositoryId = repository;
                OriginalBranch = originalBranch;
                NewBranch = newBranch;
            }

            public long RepositoryId { get; }
            public string OriginalBranch { get; }
            public string NewBranch { get; }
        }
    }
}