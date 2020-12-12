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
        public string AutoVersionPrefix { get; set; }

        [Output]
        public string AutoVersionSuffix { get; set; }

        public string ProjectDir { get; set; }

        public string TaskDir { get; set; }

        public override bool Execute()
        {
            try
            {
                var taskDirFull = Path.GetFullPath(TaskDir);
                var projectDirFull = Path.GetFullPath(ProjectDir);
                var projectInfo = ProjectHelper.GetInfo(taskDirFull, projectDirFull);

                AutoVersionPrefix = projectInfo.VersionPrefix;
                AutoVersionSuffix = projectInfo.VersionSuffix;
                AutoVersion = projectInfo.Version;
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
