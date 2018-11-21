using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using No8.Solution.Printers;
using No8.Solution.Factories;
using No8.Solution.Logger;

namespace No8.Solution
{
    /// <summary>
    /// Represent a manager for work with printers.  
    /// </summary>
    public class PrinterManager
    {
        private ILogger logger;

        public IEnumerable<Printer> Printers { get; private set; }

        private List<PrinterFactory> Factories { get; set;}

        /// <summary>
        /// Initializes a new instance of the PrinterManager class.
        /// </summary>
        /// <param name="logger">
        /// Type that implements ILogger. 
        /// </param>
        /// <exception cref="ArgumentNullException">The <paramref name="logger"/> is null.</exception>
        public PrinterManager(ILogger logger)
        {
            this.logger = logger ?? throw new ArgumentNullException($"The {nameof(logger)} can not be null.");

            //TODO Repository think 
            Printers = new List<Printer>() { new EpsonPrinter("1111"), new EpsonPrinter("2222"), new CanonPrinter("1111")};

            InitializationFactories();           
        }

        /// <summary>
        /// Create a new printer.
        /// </summary>
        /// <param name="name">
        /// The name of a printer.
        /// </param>
        /// <param name="model">
        /// The model of a printer.
        /// </param>
        /// <exception cref="ArgumentNullException">The <paramref name="name"/>is null or empty.</exception>
        /// <exception cref="ArgumentNullException">The <paramref <paramref name="model"/>/>is null or empty.</exception>
        /// <exception cref="ArgumentException">Printer with <paramref name="name"/> and <paramref name="model"/> already exists.</exception>
        /// <exception cref="ArgumentException">Printer with <paramref name="name"/> does not support for add.</exception>
        public void Add(string name, string model)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException($"The {name} can not be null or empty.");
            }
            if (string.IsNullOrEmpty(model))
            {
                throw new ArgumentNullException($"The {model} can not be null or empty.");
            }

            AddPrinter(name, model);
        }

        /// <summary>
        /// Print info from the given file.
        /// </summary>
        /// <param name="printer">
        /// Printer for work.
        /// </param>
        /// <param name="fileName">
        /// File for print.
        /// </param>
        /// <exception cref="ArgumentNullException">The <paramref name="printer"/> is null.</exception>
        /// <exception cref="ArgumentNullException">The <paramref name="fileName"/> is nul or empty.</exception>
        public void Print(Printer printer, string fileName)
        {
            if (ReferenceEquals(printer, null))
            {
                throw new ArgumentNullException($"The {nameof(printer)} can not be null.");
            }
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException($"The {nameof(fileName)} can not be null or empty.");
            }

            printer.PrintedWork += CommitPrinterEvent;

            using (FileStream fileStream = File.OpenRead(fileName))
            {
                printer.Print(fileStream);
            }  
        }

        /// <summary>
        /// Show available printer by given <paramref name="printerName"/>.
        /// </summary>
        /// <param name="printerName">
        /// The name of printer.
        /// </param>
        /// <returns>
        /// Collection of available printers or null.
        /// </returns>
        public IEnumerable<Printer> GetPrintersByName(string printerName)
        {            
            IEnumerable<Printer> printers = Printers.Where(p => p.Name == printerName).ToList();

            return printers;
        }

        /// <summary>
        /// Commit user actions in file.
        /// </summary>
        /// <param name="info">
        /// Info for commit.
        /// </param>
        /// <exception cref="ArgumentNullException">The <paramref name="info"/>is null or empty.</exception>
        public void CommitUserEventInfo(string info)
        {
            if (string.IsNullOrEmpty(info))
            {
                throw new ArgumentNullException($"The {nameof(info)} can not be null or empty.");
            }

            logger.Log(info);
        }

        private void CommitPrinterEvent(object sender, PrinterEventArgs printerEventArgs)
        {
            if (ReferenceEquals(sender, null))
            {
                throw new ArgumentNullException($"The {nameof(sender)} can not be null.");
            }

            if(ReferenceEquals(printerEventArgs, null))
            {
                throw new ArgumentNullException($"The {nameof(printerEventArgs)} can not be null.");
            }

            string printerEventInfo = $"{printerEventArgs.Name} - {printerEventArgs.Model} - {printerEventArgs.Info}";

            logger.Log(printerEventInfo);
        }
        
        private void InitializationFactories()
        {
            //TODO ASK ERROR NULL REFERENCE in thid dll when Console try load.
            //foreach (var factory in FactoryRepository.Factories)
            //{
            //    Factories.Add(factory);
            //}

            Factories = new List<PrinterFactory>() { new CanonFactory(), new EpsonFactory() };
        }

        private void AddPrinter(string name, string model)
        {
            PrinterFactory factory = CheckExistingFactory(name);

            if (ReferenceEquals(factory, null))
            {
                throw new ArgumentException($"The printer {name} does not support. You can not add such printer.");
            }
            else if (!IsExistsPrinter(name, model))
            {
                throw new ArgumentException($"Printer {name} - {model} already exists.");
            }
            else
            {
                Printer newPrinter = factory.CreatePrinter(model);
                ((List<Printer>)Printers).Add(newPrinter);
            }
        }

        private bool IsExistsPrinter(string name, string model)
        {
           Printer printer = Printers.FirstOrDefault(p => p.Name == name && p.Model == model);

           return ReferenceEquals(printer, null);
        }

        private PrinterFactory CheckExistingFactory(string name)
        {
            PrinterFactory printerFactory = Factories.FirstOrDefault(f => f.NameFactory.ToString() == name.ToUpperInvariant().Trim());

            return printerFactory;
        }

    }
}
