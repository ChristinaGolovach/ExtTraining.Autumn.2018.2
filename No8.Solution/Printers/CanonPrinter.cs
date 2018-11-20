using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No8.Solution.Printers
{
    public class CanonPrinter : Printer
    { 
        public CanonPrinter(string model) : base (model)
        {
            Name = "Canon";
        }

        protected override string PrintCore(FileStream fs)
        {
            throw new NotImplementedException();
        }

        protected override void StartPrint()
        {
            string info = "";
            OnPrintedWork(new PrinterEventArgs(Name, Model, info));
        }

        protected override void EndPrint()
        {
            string info = "";
            OnPrintedWork(new PrinterEventArgs(Name, Model, info));
        }
    }
}
