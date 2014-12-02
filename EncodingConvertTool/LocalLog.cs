using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace EncodingConvertTool
{
    public static class LocalLog
    {
        const string logFolderPath = ".\\Logs";
        public static void WhriteLog(string message)
        {
            string path = existLog(DateTime.Now.ToString("yyyyMMdd")+".log");
            File.AppendAllText(path, "\r\n" + DateTime.Now.ToShortTimeString() + " " + message);
        }
        private static string existLog(string name)
        {
            if (!Directory.Exists(logFolderPath))
            {
                Directory.CreateDirectory(logFolderPath);
                File.Create(logFolderPath + "\\" + name).Close();
            }
            else if (!File.Exists(logFolderPath + "\\" + name))
                File.Create(logFolderPath + "\\" + name).Close();
            return logFolderPath + "\\" + name;
        }
    }
}
