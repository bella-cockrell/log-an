using System;

namespace LogAn
{
    public class LogAnalyzer
    {
        private IFileExtensionManager manager;

        public LogAnalyzer()
        {
            manager = new FileExtensionManager();
        }
        //defines the constructor that can be called by tests

        public IFileExtensionManager FileExtensionManager
        {
            get { return manager; }
            set { manager = value; }
        }

        public bool IsValidLogFileName(string fileName)
        {

            return manager.IsValid(fileName);

        }

    }
}
