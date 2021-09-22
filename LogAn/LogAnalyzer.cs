using System;

namespace LogAn
{
    public class LogAnalyzer
    {
        private IFileExtensionManager manager;

        public LogAnalyzer()
        {
            var factory = new ExtensionManagerFactory(); //in the examples, these weren't instatiated? 
            manager = factory.Create();
        }   
      
        public bool IsValidLogFileName(string fileName)
        {

            return manager.IsValid(fileName);
                //&& Path.GetFileNameWithoutExtension(fileName).Length > 5;

        }

    }
}
