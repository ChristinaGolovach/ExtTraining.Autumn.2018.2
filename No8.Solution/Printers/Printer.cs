using System;
using System.IO;

namespace No8.Solution.Printers
{
    /// <summary>
    /// Represent a Printer class.
    /// </summary>
    public abstract class Printer
    {
        /// <summary>
        /// Event of start or end printer work.
        /// </summary>
        public event EventHandler<PrinterEventArgs> PrintedWork = delegate { };

        private string name;
        private string model;

        /// <summary>
        /// Return the name of printer.
        /// </summary>
        public string Name
        {
           get => name;
           protected internal set => name = value ?? throw new ArgumentNullException($"The {name} can not be null.");
        }

        /// <summary>
        /// Return the model of printer.
        /// </summary>
        public string Model
        {
            get => model;
            private set => model = value ?? throw new ArgumentNullException($"The {model} can not be null.");
        }

        /// <summary>
        /// Initializes a new instance of the Printer.
        /// </summary>
        /// <param name="model">
        /// The name of model.
        /// </param>
        /// <exception cref="ArgumentNullException">The <paramref name="model"/>is null.</exception>
        public Printer(string model)
        {
            Model = model;
        }

        /// <summary>
        /// Performs print of given unformation in <paramref name="fileStream"/>.
        /// </summary>
        /// <param name="fileStream">
        /// File stream with information for print.
        /// </param>
        /// <exception cref="ArgumentNullException">The <paramref name="fileStream"/>is null.</exception>
        public void Print(FileStream fileStream)
        {
            if (fileStream == null)
            {
                throw new ArgumentNullException($"The {nameof(fileStream)} can not be null.");
            }

            StartPrint();

            PrintCore(fileStream);

            EndPrint();
        }

        protected abstract void PrintCore(FileStream fs);

        protected virtual void OnPrintedWork(PrinterEventArgs e)
        {
            if (ReferenceEquals(e, null))
            {
                throw new ArgumentNullException($"The {typeof(PrinterEventArgs)} can not be null.");
            }

            PrintedWork?.Invoke(this, e);
        }

        private void StartPrint()
        {
            string info = $"Start work - {DateTime.Now}";
            PrinterEventArgs eventArgs = new PrinterEventArgs(Name, Model, info);
            OnPrintedWork(eventArgs);
        }

        private void EndPrint()
        {
            string info = $"End work - {DateTime.Now}";
            PrinterEventArgs eventArgs = new PrinterEventArgs(Name, Model, info);
            OnPrintedWork(eventArgs);
        }
    }
}
