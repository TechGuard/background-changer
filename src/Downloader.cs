using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;

namespace BackgroundChanger
{
    class Downloader
    {
        /// <summary>
        /// Download image from url
        /// </summary>
        /// <param name="url">source</param>
        /// <param name="dest">destination</param>
        /// <param name="format">image format default jpeg</param>
        public static void DownloadImageToFile(string url, string dest, ImageFormat format = null)
        {
            if(format == null)
            {
                format = ImageFormat.Jpeg;
            }

            using (WebClient webClient = new WebClient())
            {
                byte[] data = webClient.DownloadData(url);

                using (MemoryStream stream = new MemoryStream(data))
                {
                    using (var image = Image.FromStream(stream))
                    {
                        image.Save(dest, ImageFormat.Jpeg);
                    }
                }
            }
        }

    }
}
