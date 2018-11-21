using System;
using System.IO;

namespace No8.Solution.Logger
{
    public class Logger : ILogger
    {
        public Logger() { }

        public void Log(string info)
        {
            using (StreamWriter streamWriter = File.AppendText("log.txt"))
            {
                streamWriter.Write(info + Environment.NewLine);
            }            
        }
    }
}
