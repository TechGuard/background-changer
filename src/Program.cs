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

            // Start without delay
            OnTick(null, null);

            // Keep application running
            Console.ReadLine();
        }

        private static void OnTick(object source, ElapsedEventArgs e)
        {
            Desktop.Update();
            Console.WriteLine("Updated desktop");
        }
    }
}