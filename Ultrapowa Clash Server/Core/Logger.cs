using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Convert;

namespace UCS.Core
{
    internal class Logger
    {
        static int getlevel = ToInt32(ConfigurationManager.AppSettings["LogLevel"]);
        static string path = "Logs/log.txt";

        public static void Write(string text)
        {
            if(getlevel == 0)
            {
                // Nothing
            }
            else if(getlevel == 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[LOG]    " + text);
                Console.ResetColor();
                using (StreamWriter sw = new StreamWriter(path, true))
                {
                    sw.WriteLine("[LOG]    " + text + " at " + DateTime.UtcNow);
                }
            }
        }

        public void Start()
        {
            if (getlevel > 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine();
                Console.WriteLine("Please choose a valid Log Level");
                Console.WriteLine("UCS Emulator is now closing...");
                Console.ResetColor();
                Thread.Sleep(5000);
                Environment.Exit(0);
            }
        }
    }
}
