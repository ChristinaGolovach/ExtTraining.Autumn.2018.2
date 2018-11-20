using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using No8.Solution.Printers;

namespace No8.Solution.Factories
{
    public class CanonFactory : PrinterFactory
    {
        public override PrinterNameEnum NameFactory => PrinterNameEnum.Canon;

        public override Printer CreatePrinter(string model)
        {
            return new CanonPrinter(model);
        }
    }
}
