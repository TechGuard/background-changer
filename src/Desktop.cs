using System.IO;
using System.Threading;

namespace BackgroundChanger
{
    class Desktop
    {
        /// <summary>
        /// Update desktop wallpaper with new images
        /// </summary>
        public static void Update()
        {
            int totalImages = Config.GetInt("total");
            string folder = Config.GetString("folder");
            string source = Config.GetString("source");

            if(!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            for (int index = 1; index <= totalImages; index++)
            {
                string number = index.ToString("D" + totalImages.ToString().Length);
                string destinationFile = Path.Combine(folder, "desktop_" + number + ".jpg");

                Downloader.DownloadImageToFile(source, destinationFile);
                Thread.Sleep(5000);
            }
        }
    }
}