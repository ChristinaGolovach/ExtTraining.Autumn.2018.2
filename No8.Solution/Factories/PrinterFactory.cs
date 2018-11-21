using No8.Solution.Printers;

namespace No8.Solution.Factories
{
    /// <summary>
    /// Represents a class that designed to create an instance of <see cref="T:No8.Solution.Printers.Printer"/>
    /// </summary>
    public abstract class PrinterFactory
    {
        public abstract PrinterNameEnum NameFactory { get; }

        /// <summary>
        /// Create a new instance of <see cref="T:No8.Solution.Printers.Printer"/>.
        /// </summary>
        /// <param name="model">The name of model.</param>
        /// <returns>
        /// Object reference to <see cref="T:No8.Solution.Printers.Printer"/>
        /// </returns>
        public abstract Printer CreatePrinter(string model);
    }
}
