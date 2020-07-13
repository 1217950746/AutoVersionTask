using System;
using System.IO;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace AutoVersionTask
{
    public class MainTask : Task
    {
        [Output]
        public string AutoVersion { get; set; }

        [Output]
        public string AutoVersionSuffix { get; set; }

        [Output]
        public string AutoFullVersion { get; set; }

        public string TaskDir { get; set; }
        public string ProjectDir { get; set; }

        public override bool Execute()
        {
            try
            {
                var commitInfo = ProjectHelper.GetInfo(Path.GetFullPath(TaskDir), Path.GetFullPath(ProjectDir));

                AutoVersion = $"{commitInfo.BuildTime:yy.M.d}.{commitInfo.Number}";
                AutoVersionSuffix = $"{commitInfo.Sha}-{commitInfo.BuildNumber}";
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