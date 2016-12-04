using MefPluginsManager;
using System;
using System.IO;

namespace AssetManagementApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Logger _logger = new Logger();

            _logger.LogMessage("Log Test 1");
            _logger.LogMessage("Log Test 2");
            _logger.LogMessage("Log Test 3");

            // Read Log
            ReadLog();
            Console.ReadKey();
        }


        public static void ReadLog()
        {
            // Process the list of files found in the directory.
            string[] fileEntries = Directory.GetFiles(GetTemporaryDirectory());
            foreach (string fileName in fileEntries)
            {
                string contents = File.ReadAllText(fileName);
                Console.WriteLine(fileName);
                Console.WriteLine(contents);
            }
        }

        public static string GetTemporaryDirectory()
        {
            string tempDirectory = Path.Combine(Path.GetTempPath(), "AssetManagementApp");
            Directory.CreateDirectory(tempDirectory);
            return tempDirectory;
        }
    }
}
