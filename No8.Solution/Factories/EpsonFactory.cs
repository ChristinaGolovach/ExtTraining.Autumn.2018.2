using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using No8.Solution.Printers;

namespace No8.Solution.Factories
{
    public class EpsonFactory : PrinterFactory
    {
        public override PrinterNameEnum NameFactory => PrinterNameEnum.Epson;

        public override Printer CreatePrinter(string model)
        {
            return new EpsonPrinter(model);
        }
    }
}
