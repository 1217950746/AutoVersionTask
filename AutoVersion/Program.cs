using System;
using System.IO;
using System.Linq;
using AutoVersionTask;

namespace AutoVersion
{
    static class Program
    {
        static void Main()
        {
            var exe = Environment.GetCommandLineArgs().First();
            var dir = Path.GetDirectoryName(exe);
            Console.WriteLine(ProjectHelper.GetInfo(dir, dir).Version);
        }
    }
}
