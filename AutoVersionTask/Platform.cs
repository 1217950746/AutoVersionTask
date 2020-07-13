using System;

namespace AutoVersionTask
{
    static class Platform
    {
        public static bool IsNetCore()
        {
            return !IsNet();
        }

        public static bool IsNet()
        {
            return typeof(object).Assembly.GetName().Name == "mscorlib";
        }

        public static bool Is64()
        {
            return IntPtr.Size == 8;
        }
    }
}