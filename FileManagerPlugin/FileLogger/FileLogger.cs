using Contracts;
using System;
using System.ComponentModel.Composition;
using System.IO;

namespace FileManagerPlugin.FileLogger
{
    [Export(typeof(ILogger))]
    public class FileLogger : ILogger
    {
        public string LogType
        {
            get
            {
                return "Logger to file";
            }
        }

        public void Log(string message)
        {
            string logTempFilePath = Path.Combine(GetTemporaryDirectory(), string.Format("Log_{0}.xml", DateTime.Now.ToFileTimeUtc()));

            if (File.Exists(logTempFilePath))
            {
                File.Delete(logTempFilePath);
            }

            StreamWriter sw = File.AppendText(logTempFilePath);
            sw.WriteLine(message);
            sw.Close();
        }

        public string GetTemporaryDirectory()
        {
            string tempDirectory = Path.Combine(Path.GetTempPath(), "AssetManagementApp");
            Directory.CreateDirectory(tempDirectory);
            return tempDirectory;
        }
    }
}
