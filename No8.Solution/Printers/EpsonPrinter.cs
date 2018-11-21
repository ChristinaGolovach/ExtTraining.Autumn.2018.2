using System;
using System.IO;

namespace No8.Solution.Printers
{
    public class EpsonPrinter : Printer
    {
        public EpsonPrinter(string model) : base (model)
        {
            Name = "Epson";
        }

        protected override void PrintCore(FileStream fileStream)
        {
            for (int i = 0; i < fileStream.Length; i++)
            {
                // simulate printing
                Console.WriteLine(fileStream.ReadByte());
            }
        }
    }
}
