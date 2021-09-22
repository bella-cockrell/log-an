using System;

namespace LogAn
{
    public class ExtensionManagerFactory
    {
        private IFileExtensionManager customManager = null;

        public IFileExtensionManager Create()
        {
            if (customManager != null)
            {
                return customManager;
            }

            return new FileExtensionManager();

        }

        public void SetManager(IFileExtensionManager mgr)
        {
            customManager = mgr;
        }
    }

}
