using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace AutoVersionTask
{
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    public class MainTask : Task
    {
        [Output]
        public string AutoVersion { get; set; }

        public string ProjectDir { get; set; }

        public string TaskDir { get; set; }

        public override bool Execute()
        {
            try
            {
                var taskDirFull = Path.GetFullPath(TaskDir);
                var projectDirFull = Path.GetFullPath(ProjectDir);
                var projectInfo = ProjectHelper.GetInfo(taskDirFull, projectDirFull);
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
