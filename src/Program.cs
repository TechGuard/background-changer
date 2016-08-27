using System;
using System.IO;

namespace BackgroundChanger
{
    class Program
    {
        static void Main(string[] args)
        {
            string dest = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "cat.jpg");
            Downloader.DownloadImageToFile("https://c2.staticflickr.com/1/70/175237265_029f7974a2_b.jpg", dest);
        }
    }
}