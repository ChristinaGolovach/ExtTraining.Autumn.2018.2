using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No8.Solution.Printers
{
    public class EpsonPrinter : Printer
    {
        public EpsonPrinter(string model) : base (model)
        {
            Name = "Epson";
        }

        protected override string PrintCore(FileStream fs)
        {
            for (int i = 0; i < fs.Length; i++)
            {
                // simulate printing
                Console.WriteLine(fs.ReadByte());
            }

            throw new NotImplementedException();
        }

        protected override string EndPrint()
        {
            throw new NotImplementedException();
        }

        protected override string StartPrint()
        {
            throw new NotImplementedException();
        }
    }
}
