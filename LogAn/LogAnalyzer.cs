using System;

namespace LogAn
{
    public class LogAnalyzerUsingFactoryMethod
    {
      
        public bool IsValidLogFileName(string fileName)
        {
            return GetManager().IsValid(fileName); //uses virtual GetManager() method
        }

        protected virtual IFileExtensionManager GetManager()
        {
            return new FileExtensionManager(); //returns hardcoded value
        }

    }
}
