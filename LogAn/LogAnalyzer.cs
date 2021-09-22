using System;

namespace LogAn
{
    public class LogAnalyzer
    {
        private IFileExtensionManager manager;

        public LogAnalyzer (IFileExtensionManager extensionManager)
        {
            manager = extensionManager;
        }
        //defines the constructor that can be called by tests

        public bool IsValidLogFileName(string fileName)
        {

            return manager.IsValid(fileName);

        }

    }
}
