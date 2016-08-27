using System;
using System.Threading;

namespace BackgroundChanger
{
    class AppLock : IDisposable
    {
        public static readonly string AppName = "{61cc2cf5-3674-4e8f-b7d5-0838f1cfb5a3}";

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
