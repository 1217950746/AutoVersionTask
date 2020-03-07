using System;
using System.Diagnostics;
using System.Reflection;

namespace AutoVersionTask.Test
{
    static class Program
    {
        static void Main()
        {
            var version = Assembly.GetEntryAssembly()?.GetName().Version;
            Debug.WriteLine(version);
            Console.WriteLine(version);
        }
    }
}