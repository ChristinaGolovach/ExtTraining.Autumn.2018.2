using No8.Solution.Printers;

namespace No8.Solution.Factories
{
    public class CanonFactory : PrinterFactory
    {
        public override PrinterNameEnum NameFactory => PrinterNameEnum.CANON;

        public override Printer CreatePrinter(string model)
        {
            return new CanonPrinter(model);
        }
    }
}
