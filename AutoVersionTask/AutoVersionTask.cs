using System;
using System.IO;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace AutoVersionTask
{
    public class AutoVersionTask : Task
    {
        [Output]
        public string AutoVersion { get; set; }

        [Output]
        public string AutoVersionSuffix { get; set; }

        [Output]
        public string AutoFullVersion { get; set; }

        public string SolutionDir { get; set; }

        public override bool Execute()
        {
            try
            {
                if (!Directory.Exists(SolutionDir))
                    throw new Exception($"Not Found {SolutionDir}");

                var buildSha = Helper.Run(SolutionDir, "git", "rev-parse", "--short", "HEAD");
                var buildNumber = Helper.Run(SolutionDir, "git", "rev-list", "HEAD", "--count");
                var todayBuildNumber = Helper.Run(SolutionDir, "git", "rev-list", "HEAD", "--count", "--after", $"\"{DateTime.Now:yyyy.MM.dd} 00:00\"");

                AutoVersion = $"{DateTime.Now:yy.M.d}.{todayBuildNumber}";
                AutoVersionSuffix = $"{buildSha}-{buildNumber}";
                AutoFullVersion = $"{AutoVersion}-{AutoVersionSuffix}";
            }
            catch (Exception ex)
            {
                Log.LogError(ex.ToString());
                return false;
            }

            return true;
        }
    }
}