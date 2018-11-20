using System;
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


        protected override string StartPrint()
        {
            //return  Name;
            throw new NotImplementedException();
        }

        protected override string EndPrint()
        {
            throw new NotImplementedException();
        }
    }
}
