using System;

namespace AutoVersionTask
{
    public class ProjectInfo
    {
        public DateTime BuildTime { get; set; } = DateTime.Now;
        public int Number { get; set; } = 1;

        public string Version
        {
            get => $"{BuildTime:yyyy.M.d}.{Number}";
        }
    }
}
