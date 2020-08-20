using System.Diagnostics;
using System.Reflection;

namespace AutoVersion
{
    static class Program
    {
        static void Main()
        {
            Debug.WriteLine(Assembly.GetExecutingAssembly().GetName().Version);
        }
    }
}