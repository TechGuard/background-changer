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

                    Desktop.Update();
                    Console.WriteLine("Updated desktop");

                    Thread.Sleep(interval);
                }
            }
        }
    }
}