using System;
using System.Diagnostics;
using System.IO;

namespace ConsoleApp1
{
    class Logger : ILogger
    {
        private const string direct = @"C:\Users\KDM\Desktop";
        private const string fileName = "Log.txt";
        private readonly string path = $@"{direct}\{fileName}";

        public void LogText(object log) {
            ExistFile(path);
            //ExecuteSaveLog(path, LogFormat(log.ToString()));
        }

        public string LogFormat(string log) {
           // StackTrace line;
            // TODO: StackTrace when throw message :: Format [date] line msg
            string date = DateTime.Now.ToString("yyyy'-'MM'-'dd' 'HH':'mm':'ss");
            return $"[{date}] :: {log}";
        }

        private void ExistFile(string path) {
            File.Create(path);
        }

        private void ExecuteSaveLog(string path, string log) {
            File.AppendAllText(path, log);
        }
    }
}
