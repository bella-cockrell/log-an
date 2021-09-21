using System;

namespace LogAnLibrary
{
    public class LogAnalyzer
    {
        public static bool IsValidLogFileName(string fileName)
        {
            if (fileName.EndsWith(".SLF"))
            {
                return false;
            }

            return true;
        }

    }
}
