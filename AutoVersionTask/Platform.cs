using System;

namespace AutoVersionTask
{
    static class Platform
    {
        public static bool Is64()
        {
            return IntPtr.Size == 8;
        }

        public static bool IsNet()
        {
            return typeof(object).Assembly.GetName().Name == "mscorlib";
        }

        public static bool IsNetCore()
        {
            return !IsNet();
        }
    }
}
