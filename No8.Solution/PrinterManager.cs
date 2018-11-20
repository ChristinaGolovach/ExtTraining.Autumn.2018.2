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
    public static class PrinterManager
    {
        public static IEnumerable<Printer> Printers { get; private set; }
        private static List<PrinterFactory> Factories { get; set;}

        static PrinterManager()
        {
            Printers = new List<Printer>() { new EpsonPrinter("1111"), new EpsonPrinter("2222"), new CanonPrinter("1111")};
            InitializationFactories();
        }

        public static void Add (string name, string model)
        {
            AddPrinter(name, model);
        }

        public static void Print(Printer printer, string fileName)
        {
            Log($" Printed on {printer.Name} - {printer.Model}");
            using (FileStream fileStream = File.OpenRead(fileName))
            {
                printer.Print(fileStream);
            }                  
            Log("Print finished");
        }

        public static IEnumerable<Printer> ShowModels(PrinterNameEnum printer)
        {
            string name = printer.ToString();
            IEnumerable<Printer> printers = Printers.Where(p => p.Name == name).ToList<Printer>();
            return printers;
        }

        public static void Log(string s)
        {
            File.AppendText("log.txt").Write(s);
        }

        private static void InitializationFactories()
        {
            Factories = new List<PrinterFactory>() { new CanonFactory(), new EpsonFactory() };
        }

        private static void AddPrinter(string name, string model)
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

        private static bool CheckExistsPrinter(string name, string model)
        {
           Printer printer = Printers.FirstOrDefault(p => p.Name == name && p.Model == model);

           return ReferenceEquals(printer, null);
        }

        private static PrinterFactory CheckExistsFactory(string name)
        {
            PrinterFactory printerFactory = Factories.FirstOrDefault(f => f.NameFactory.ToString() == name);

            return printerFactory;
        }

    }
}
