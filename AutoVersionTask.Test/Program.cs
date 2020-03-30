using System;
using System.Diagnostics;

namespace AutoVersionTask.Test
{
    static class Program
    {
        static void Main(string[] args)
        {
            var commitInfo = Helper.GetCommitInfo(args[0]);
            var version = $"{commitInfo.BuildTime:yy.M.d}.{commitInfo.Number}-{commitInfo.Sha}-{commitInfo.BuildNumber}";
            Debug.WriteLine(version);
            Console.WriteLine(version);
            Console.ReadKey(true);
        }
    }
}