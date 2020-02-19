using System.Diagnostics;
using System.Reflection;

namespace AutoVersionTask.Test
{
    static class Program
    {
        static void Main()
        {
            Debug.WriteLine(Assembly.GetEntryAssembly()?.GetName().Version);
        }
    }
}