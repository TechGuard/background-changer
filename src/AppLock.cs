using System;
using System.IO;
using System.Threading;

namespace BackgroundChanger
{
    class AppLock : IDisposable
    {
        public static readonly string AppName = "{079216d0-a9bb-4ddf-ad89-5c1042f2efd7}";

        private Mutex mutex;


        /// <summary>
        /// Try to lock application
        /// </summary>
        public AppLock()
        {
            mutex = new Mutex(false, AppName);
            if (!mutex.WaitOne(0, false))
            {
                throw new ApplicationException("Already running");
            }
        }

        /// <summary>
        /// Unlock application
        /// </summary>
        public void Dispose()
        {
            mutex.Dispose();
        }
    }
}
