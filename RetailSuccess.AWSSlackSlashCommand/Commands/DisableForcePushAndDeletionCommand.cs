using System;
using pb = Paramore.Brighter;

namespace RetailSuccess.GitHub.Commands
{
    public static partial class DisableForcePushAndDeletion
    {
        public sealed class Command : pb.Command
        {
            public Command(long repositoryId, string branchName = "develop") : base(Guid.NewGuid())
            {
                BranchName = branchName;
                RepositoryId = repositoryId;
            }

            public string BranchName { get; }
            public long RepositoryId { get; }
        }
    }
}