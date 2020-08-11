using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace Min_Helpers.LogHelper
{
    /// <summary>
    /// Log
    /// </summary>
    public class Log
    {
        /// <summary>
        /// Log Path
        /// </summary>
        /// <value>default - "./logs"</value>
        public string LogPath { get; set; } = "./logs";

        /// <summary>
        /// Template of Log File Name
        /// </summary>
        /// <value>default - "{{type}}-{{date}}-{{index}}.log"</value>
        public string LogFileName { get; set; } = "{{type}}-{{date}}-{{index}}.log";

        /// <summary>
        /// Max Size of Log File
        /// </summary>
        /// <value>default - "10000000"</value>
        public int LogFileLimitSize { get; set; } = 10000000;

        /// <summary>
        /// Write Log
        /// </summary>
        /// <param name="message"></param>
        public void Write(string message)
        {
            try
            {
                this.Write(message, "log");
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Write Log with Type
        /// </summary>
        /// <param name="message"></param>
        /// <param name="type"></param>
        public void Write(string message, string type)
        {
            try
            {
                DateTime now = DateTime.Now;

                string filename = $"{this.LogPath}\\{this.LogFileName.Replace("{{type}}", type).Replace("{{date}}", now.ToString("yyyy-MM-dd"))}";

                for (int i = 1; true; i++) {
                    string _filename = filename.Replace("{{index}}", i.ToString());
                    FileInfo _fileInfo = new FileInfo(_filename);

                    if (_fileInfo.Exists && _fileInfo.Length >= this.LogFileLimitSize)
                    {
                        continue;
                    }

                    filename = _filename;
                    break;
                }

                FileInfo fileInfo = new FileInfo(filename);

                if (!fileInfo.Directory.Exists)
                {
                    fileInfo.Directory.Create();
                }

                using (FileStream fileStream = new FileStream(fileInfo.FullName, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
                {
                    using (StreamWriter writer = new StreamWriter(fileStream))
                    {
                        writer.WriteLine(message);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
