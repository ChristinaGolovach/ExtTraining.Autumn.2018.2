using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using No8.Solution.Printers;
using No8.Solution.Factories;

namespace No8.Solution
{
    public class PrinterManager
    {
        public IEnumerable<Printer> Printers { get; private set; }
        private List<PrinterFactory> Factories { get; set;}

        public PrinterManager()
        {
            Printers = new List<Printer>() { new EpsonPrinter("1111"), new EpsonPrinter("2222"), new CanonPrinter("1111")};
            InitializationFactories();
        }

        public  void Add (string name, string model)
        {

            AddPrinter(name, model);
        }

        public void Print(Printer printer, string fileName)
        {
            if (ReferenceEquals(printer, null))
            {
                throw new ArgumentNullException($"The {nameof(printer)} can not be null.");
            }
            if (fileName == null)
            {
                throw new ArgumentNullException($"The {nameof(fileName)} can not be null.");
            }

            Log($" Printed on {printer.Name} - {printer.Model}");

            using (FileStream fileStream = File.OpenRead(fileName))
            {
                printer.Print(fileStream);
            }  
            
            Log("Print finished");
        }

        public IEnumerable<Printer> ShowModels(string printerName)        {
            
            IEnumerable<Printer> printers = Printers.Where(p => p.Name == printerName).ToList<Printer>();

            return printers;
        }

        public  void Log(string s)
        {
            File.AppendText("log.txt").Write(s);
        }

        private  void InitializationFactories()
        {
            Factories = new List<PrinterFactory>() { new CanonFactory(), new EpsonFactory() };
        }

        private  void AddPrinter(string name, string model)
        {
            PrinterFactory factory = CheckExistsFactory(name);

            if (factory == null)
            {
                throw new ArgumentException($"The printer {name} does not support.");
            }

            else if (CheckExistsPrinter(name, model))
            {
               Printer newPrinter = factory.CreatePrinter(model);
               ((List<Printer>)Printers).Add(newPrinter);
            }            
        }

        private  bool CheckExistsPrinter(string name, string model)
        {
           Printer printer = Printers.FirstOrDefault(p => p.Name == name && p.Model == model);

           return ReferenceEquals(printer, null);
        }

        private  PrinterFactory CheckExistsFactory(string name)
        {
            PrinterFactory printerFactory = Factories.FirstOrDefault(f => f.NameFactory.ToString() == name);

            return printerFactory;
        }

    }
}
