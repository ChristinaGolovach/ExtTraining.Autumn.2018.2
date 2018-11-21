using System;

namespace No8.Solution.Logger
{
    /// <summary>
    /// Contract for the logger type.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Record input data in some storage.
        /// </summary>
        /// <param name="info">
        /// Data for log.
        /// </param>
        void Log(string info);
    }
}
