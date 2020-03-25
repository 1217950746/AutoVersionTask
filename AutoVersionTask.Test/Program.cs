using System;
using System.Diagnostics;

namespace AutoVersionTask.Test
{
    static class Program
    {
        static void Main()
        {
            var commitInfo = Helper.GetCommitInfo(".");
            var version = $"{commitInfo.BuildTime:yy.M.d}.{commitInfo.Number}-{commitInfo.Sha}-{commitInfo.BuildNumber}";
            Debug.WriteLine(version);
            Console.WriteLine(version);
        }
    }
}