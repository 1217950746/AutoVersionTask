using System;
using System.IO;
using System.Linq;
using LibGit2Sharp;

namespace AutoVersionTask
{
    public static class ProjectHelper
    {
        static bool isGitInit;

        public static ProjectInfo GetInfo(string taskDir, string projectDir)
        {
            if (!isGitInit)
            {
                isGitInit = true;

                if (Platform.IsNet())
                    GlobalSettings.NativeLibraryPath = Path.Combine(taskDir, "lib", "win32");
                else
                    GlobalSettings.NativeLibraryPath = Path.Combine(taskDir, "lib", "win32", Platform.Is64() ? "x64" : "x86");
            }

            if (string.IsNullOrWhiteSpace(projectDir))
                return new ProjectInfo();

            var discover = Repository.Discover(projectDir);
            if (!Directory.Exists(discover))
                return new ProjectInfo();

            using var repository = new Repository(discover);
            var buildNumber = repository.Commits.Count();
            if (buildNumber <= 0)
                return new ProjectInfo();

            var commit = repository.Commits.FirstOrDefault();
            if (commit == null)
                return new ProjectInfo();

            var commitTime = commit.Author.When.DateTime;
            var startDate = new DateTime(commitTime.Year, commitTime.Month, commitTime.Day, 0, 0, 0);
            var endDate = startDate.AddDays(1);
            var start = new DateTimeOffset(startDate);
            var end = new DateTimeOffset(endDate);
            var number = repository.Commits.Count(x => x.Author.When >= start && x.Author.When < end);

            return new ProjectInfo
            {
                Sha = commit.Sha.Substring(0, 7).ToUpper(),
                Number = number,
                BuildNumber = buildNumber,
                BuildTime = commit.Author.When.DateTime
            };
        }
    }
}