using System;

namespace AutoVersionTask
{
    public class CommitInfo
    {
        public string Sha { get; set; }
        public int Number { get; set; }
        public int BuildNumber { get; set; }
        public DateTime BuildTime { get; set; }
    }
}