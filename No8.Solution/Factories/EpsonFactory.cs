using No8.Solution.Printers;

namespace No8.Solution.Factories
{
    public class EpsonFactory : PrinterFactory
    {
        public override PrinterNameEnum NameFactory => PrinterNameEnum.EPSON;

        public override Printer CreatePrinter(string model)
        {
            return new EpsonPrinter(model);
        }
    }
}
