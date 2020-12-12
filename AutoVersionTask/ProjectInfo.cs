using System;

namespace AutoVersionTask
{
    public class ProjectInfo
    {
        public int BuildNumber { get; set; } = 1;
        public DateTime BuildTime { get; set; } = DateTime.Now;
        public int Number { get; set; } = 1;

        public string Version
        {
            get => $"{VersionPrefix}-{VersionSuffix}";
        }

        public string VersionPrefix
        {
            get => $"{BuildTime:yyyy.M.d}.{Number}";
        }

        public string VersionSuffix
        {
            get => $"R{BuildNumber}";
        }
    }
}
