using System;
using System.IO;

namespace No8.Solution.Printers
{
    public class CanonPrinter : Printer
    { 
        public CanonPrinter(string model) : base (model)
        {
            Name = "Canon";
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
