using System;
using System.Threading;

namespace BackgroundChanger
{
    class Program
    {
        static void Main(string[] args)
        {
            using (new AppLock())
            {
                while (true)
                {
                    Config.Reload();
                    int interval = Config.GetInt("interval") * 60 * 1000;

                    try
                    {
                        Desktop.Update();
                        Console.WriteLine("Updated desktop");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error occured.");
                        Console.WriteLine(ex);
                    }

                    Thread.Sleep(interval);
                }
            }
        }
    }
}