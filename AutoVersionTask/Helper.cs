using System;
using System.IO;
using System.Linq;
using LibGit2Sharp;

namespace AutoVersionTask
{
    public static class Helper
    {
        public static CommitInfo GetCommitInfo(string dir)
        {
            var discover = Repository.Discover(dir);
            if (Directory.Exists(discover))
                throw new Exception("No Repository");

            using var repository = new Repository(discover);
            var buildNumber = repository.Commits.Count();
            if (buildNumber <= 0)
                throw new Exception("No Commits");

            var commit = repository.Commits.FirstOrDefault();
            if (commit == null)
                throw new Exception("No Commit");

            var commitTime = commit.Author.When.DateTime;
            var startDate = new DateTime(commitTime.Year, commitTime.Month, commitTime.Day, 0, 0, 0);
            var endDate = startDate.AddDays(1);
            var start = new DateTimeOffset(startDate);
            var end = new DateTimeOffset(endDate);
            var number = repository.Commits.Count(x => x.Author.When >= start && x.Author.When < end);

            return new CommitInfo
            {
                Sha = commit.Sha.Substring(0, 7).ToUpper(),
                Number = number,
                BuildNumber = buildNumber,
                BuildTime = commit.Author.When.DateTime
            };
        }
    }
}