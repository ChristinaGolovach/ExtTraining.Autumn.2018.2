using System;
using System.IO;

namespace No8.Solution.Printers
{
    /// <summary>
    /// Represent a Canon printer class.
    /// </summary>
    public class CanonPrinter : Printer
    {
        /// <summary>
        /// Initializes a new instance of the Canon Printer.
        /// </summary>
        /// <param name="model">
        /// Model of printer.
        /// </param>
        /// <exception cref="ArgumentNullException">The <paramref name="model"/>is null.</exception>
        public CanonPrinter(string model) : base (model)
        {
            Name = "Canon";
        }

        protected override void PrintCore(FileStream fileStream)
        {
            for (int i = 0; i < fileStream.Length; i++)
            {
                ////TODO ASK byte or string print
                // simulate printing
                Console.WriteLine(fileStream.ReadByte());
            }
        }
    }
}
