using System;

namespace AutoVersionTask
{
    public static class VersionHelper
    {
        public static string GetVersion()
        {
            return $"{DateTime.Now:yyyy.M.d.HHmm}";
        }
    }
}
