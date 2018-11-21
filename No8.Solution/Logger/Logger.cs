using System;
using System.IO;

namespace No8.Solution.Logger
{
    /// <summary>
    /// Represent a class for log information.
    /// </summary>
    public class Logger : ILogger
    {
        /// <summary>
        /// Initializes a new instance of the Logger.
        /// </summary>
        public Logger() { }

        /// <summary>
        /// Writes given information in file log.txt.
        /// </summary>
        /// <param name="info">
        /// Information for record in the log file.
        /// </param>
        /// <exception cref="ArgumentNullException">The <paramref name="info"/>is null.</exception>
        public void Log(string info)
        {
            if (info == null)
            {
                throw new ArgumentNullException($"The {nameof(info)} can not be null.");
            }

            using (StreamWriter streamWriter = File.AppendText("log.txt"))
            {
                streamWriter.Write(info + Environment.NewLine);
            }            
        }
    }
}
