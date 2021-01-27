using System.Diagnostics;
using AutoVersionTask;

namespace AutoVersion
{
    static class Program
    {
        static void Main()
        {
            Debug.WriteLine(VersionHelper.GetVersion());
        }
    }
}
