using System;
using System.IO;
using System.Collections.Generic;

namespace BackgroundChanger
{
    class Config
    {
        public static readonly string ConfigurationFile = Path.Combine(Directory.GetCurrentDirectory(), "config.cfg");

        public static Dictionary<string, string> data = new Dictionary<string, string>();


        public static string GetString(string key)
        {
            return data[key];
        }

        public static int GetInt(string key)
        {
            return int.Parse(data[key]);
        }

        public static bool GetBool(string key)
        {
            return bool.Parse(data[key]);
        }

        public static double GetDouble(string key)
        {
            return double.Parse(data[key]);
        }

        public static float GetFloat(string key)
        {
            return float.Parse(data[key]);
        }

        /// <summary>
        /// Load configuration file
        /// </summary>
        public static void Reload()
        {
            // Create default configuration file
            if (!File.Exists(ConfigurationFile))
            {
                Create();
            }

            // Read file
            string[] lines = File.ReadAllLines(ConfigurationFile);

            // Parse file
            data.Clear();

            foreach (string line in lines)
            {
                if (line.Trim().Length == 0 || line[0] == '#')
                {
                    continue;
                }

                int index = line.IndexOf('=');
                string key = line.Substring(0, index).Trim();
                string value = line.Substring(index + 1).Trim();

                data.Add(key, value);
            }
        }

        /// <summary>
        /// Create configuration file with default contents
        /// </summary>
        private static void Create()
        {
            File.WriteAllLines(ConfigurationFile, new string[]
            {
                "#########################################",
                "# Background changer configuration file #",
                "#########################################",
                "",
                "# Source URL for retrieving image",
                "source = https://source.unsplash.com/random/1920x1080",
                "",
                "# Source URL for retrieving image",
                "folder = " + Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), "Downloaded"),
                "",
                "# Delay (in minutes) between switching images",
                "interval = 60",
                "",
                "# Total amount of images to download",
                "total = 10",
            });
        }
    }
}