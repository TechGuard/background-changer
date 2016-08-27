using System;
using System.IO;
using System.Runtime.InteropServices;

namespace BackgroundChanger
{
    class Desktop
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);

        private const int SPI_SETDESKWALLPAPER = 20;
        private const int SPIF_UPDATEINIFILE = 0x1;
        private const int SPIF_SENDWININICHANGE = 0x2;

        public static readonly string SourceUrl = "https://source.unsplash.com/random/1920x1080";
        public static readonly string DestinationFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "desktop.jpg");


        /// <summary>
        /// Update desktop wallpaper with new image
        /// </summary>
        public static void Update()
        {
            Downloader.DownloadImageToFile(SourceUrl, DestinationFile);
            SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, DestinationFile, SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);
        }
    }
}