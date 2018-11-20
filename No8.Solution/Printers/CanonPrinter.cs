using System;
using System.Collections.Generic;
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

        protected override string StartPrint()
        {
            return "Print on Canon printer";
        }

        protected override string EndPrint()
        {
            throw new NotImplementedException();
        }
    }
}
