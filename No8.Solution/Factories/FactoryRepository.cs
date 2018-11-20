using System.Collections.Generic;

namespace No8.Solution.Factories
{
    internal static class FactoryRepository
    {
        //TODO ASK 
        //Lazy<PrinterFactory>[] factories = new Lazy<PrinterFactory>[] { new Lazy<CanonFactory>() };
        public static IEnumerable<PrinterFactory> Factories = new List<PrinterFactory>() { new CanonFactory(), new EpsonFactory()};
    }
}
