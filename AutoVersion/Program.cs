using System;
using System.Diagnostics;
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
            Debug.WriteLine(ProjectHelper.GetInfo(dir, dir).Version);
        }
    }
}
