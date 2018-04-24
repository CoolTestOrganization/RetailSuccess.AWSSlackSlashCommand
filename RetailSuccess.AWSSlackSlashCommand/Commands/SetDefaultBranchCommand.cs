using System;
using Octokit;
using pb = Paramore.Brighter;

namespace RetailSuccess.GitHub.Commands
{
    public static partial class SetDefaultBranch
    {
        public sealed class Command : pb.Command
        {
            public Command(Repository repository, string branchName = "develop") : base(Guid.NewGuid())
            {
                Repository = repository;
                BranchName = branchName;
            }

            public Repository Repository { get; }
            public string BranchName { get; }
        }
    }
}