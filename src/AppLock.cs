using System;
using System.IO;

namespace BackgroundChanger
{
    class AppLock : IDisposable
    {
        public static readonly string LockFile = Path.Combine(Config.ApplicationFolder, ".locked");
        
        /// <summary>
        /// Check if lock file exists
        /// </summary>
        public static bool Check()
        {
            return File.Exists(LockFile);
        }

        /// <summary>
        /// Create lock file
        /// </summary>
        public AppLock()
        {
            if (Check())
            {
                throw new ApplicationException("Already running");
            }

            // Create directory
            if (!Directory.Exists(Config.ApplicationFolder))
            {
                Directory.CreateDirectory(Config.ApplicationFolder);
            }
            
            // Create lock file
            File.Create(LockFile);
            File.SetAttributes(LockFile, FileAttributes.Hidden | FileAttributes.ReadOnly);
        }

        /// <summary>
        /// Destroy lock file
        /// </summary>
        public void Dispose()
        {
            File.Delete(LockFile);
        }
    }
}
