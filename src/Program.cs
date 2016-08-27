using System;
using System.Timers;

namespace BackgroundChanger
{
    class Program
    {
        static void Main(string[] args)
        {
            // Start timer
            Timer timer = new Timer();
            timer.Elapsed += new ElapsedEventHandler(OnTick);
            timer.Interval = 60 * 1000;
            timer.Enabled = true;

            // Keep application running
            Console.ReadLine();
        }

        private static void OnTick(object source, ElapsedEventArgs e)
        {
            Console.WriteLine("Updated desktop");
            Desktop.Update();
        }
    }
}