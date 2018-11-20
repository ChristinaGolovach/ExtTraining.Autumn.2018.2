using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using No8.Solution.Printers;

namespace No8.Solution.Factories
{
    public abstract class PrinterFactory
    {
        public abstract PrinterNameEnum NameFactory { get; }
        public abstract Printer CreatePrinter(string model);
    }
}
