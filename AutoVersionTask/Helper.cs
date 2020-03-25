using System;
using System.IO;
using System.Linq;
using LibGit2Sharp;

namespace AutoVersionTask
{
    public static class Helper
    {
        static string FindGit(string dir)
        {
            while (true)
            {
                if (string.IsNullOrWhiteSpace(dir))
                    return string.Empty;

                if (Directory.Exists(Path.Combine(dir, ".git")))
                    return dir;

                dir = Path.GetDirectoryName(dir);
            }
        }

        public static CommitInfo GetCommitInfo(string dir)
        {
            var gitDir = FindGit(Path.GetFullPath(dir));

            using var repository = new Repository(gitDir);
            var buildNumber = repository.Commits.Count();
            if (buildNumber <= 0)
                throw new Exception("No Commits");

            var commit = repository.Commits.FirstOrDefault();
            if (commit == null)
                throw new Exception("No Commit");

            var commitTime = commit.Author.When.DateTime;
            var start = new DateTimeOffset(new DateTime(commitTime.Year, commitTime.Month, commitTime.Day, 0, 0, 0));
            var end = new DateTimeOffset(new DateTime(commitTime.Year, commitTime.Month, commitTime.Day + 1, 0, 0, 0));
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