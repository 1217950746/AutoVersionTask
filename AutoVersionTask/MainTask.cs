using System;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace AutoVersionTask
{
    public class MainTask : Task
    {
        [Output]
        public string AutoVersion { get; set; }

        public override bool Execute()
        {
            try
            {
                AutoVersion = VersionHelper.GetVersion();
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
