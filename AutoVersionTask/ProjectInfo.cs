using System;

namespace AutoVersionTask
{
    public class ProjectInfo
    {
        public string Sha { get; set; } = "0000000";
        public int Number { get; set; } = 1;
        public int BuildNumber { get; set; } = 1;
        public DateTime BuildTime { get; set; } = DateTime.Now;
    }
}