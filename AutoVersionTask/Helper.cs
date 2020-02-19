using System;
using System.Diagnostics;

namespace AutoVersionTask
{
    static class Helper
    {
        public static string Run(string dir, string command, params string[] args)
        {
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    WorkingDirectory = dir,
                    FileName = command,
                    Arguments = string.Join(" ", args),
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                }
            };
            process.Start();
            process.WaitForExit(1000);
            if (!process.HasExited)
                process.Kill();
            var output = process.StandardOutput.ReadToEnd();
            var outputError = process.StandardError.ReadToEnd();
            if (process.ExitCode != 0)
                throw new Exception($"Task Error!\n{output}\n{outputError}");

            return output.Trim();
        }
    }
}