using No8.Solution.Printers;

namespace No8.Solution.Factories
{
    public abstract class PrinterFactory
    {
        public abstract PrinterNameEnum NameFactory { get; }
        public abstract Printer CreatePrinter(string model);
    }
}
