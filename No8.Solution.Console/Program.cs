using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using No8.Solution;
using No8.Solution.Printers;
using No8.Solution.Logger;
using System.Windows.Forms;

namespace No8.Solution.Console
{
    class Program
    {
        static PrinterManager manager = new PrinterManager(new Logger.Logger());

        [STAThread]
        static void Main(string[] args)
        {       
            System.Console.WriteLine("Select your choice:");
            System.Console.WriteLine("0:Exit");
            System.Console.WriteLine("1:Add new printer");

            Dictionary<int, string> availablePrinterNames = ShowAvailablePrinters();          

            var key = System.Console.ReadKey();           

            while (key.Key != ConsoleKey.D0)
            {
                if (key.Key == ConsoleKey.D1)
                {
                    CreatePrinter();
                }
                else
                {
                    int inputPrinterNumber = 0;

                    bool converResult = int.TryParse(key.KeyChar.ToString(), out inputPrinterNumber);

                    if (converResult && availablePrinterNames.ContainsKey(inputPrinterNumber))
                    {
                        Print(availablePrinterNames[inputPrinterNumber]);
                    }
                    else
                    {
                        System.Console.WriteLine(Environment.NewLine + "Please, choice correct number for print.");
                        key = System.Console.ReadKey();
                        continue;
                    }
                }
            }
        }

        private static void Print(string printerName)
        {
            System.Console.WriteLine(Environment.NewLine + $"Choise printer model for {printerName}");

            Dictionary<int, string> availableModels = ShowAvailablePrinterModels(printerName);

            string modelNumber = GetUserChoiceOfModel(availableModels);

            string fileName = ChoiceFile();

            Printer printer = manager.Printers.FirstOrDefault(p => p.Name == printerName && p.Model == modelNumber);

            manager.Print(printer, fileName);
            
        }

        private static void CreatePrinter()
        {
            System.Console.WriteLine("Enter printer name");

            string name = System.Console.ReadLine();

            System.Console.WriteLine("Enter printer model");

            string model = System.Console.ReadLine();

            manager.Add(name, model);
        }
        
        private static string ChoiceFile()
        {
            var fileDialog = new OpenFileDialog();

            fileDialog.ShowDialog();

            string fileName = fileDialog.FileName;

            return fileName;
        }

        private static Dictionary<int, string> ShowAvailablePrinters()
        {
            int key = 2;
            int consoleKey = 2;    
            
            var printerNames = manager.Printers.OrderBy(p => p.Name).Select(p => p.Name).Distinct();

            Dictionary<int, string> dictionaryNames = printerNames.ToDictionary(name => key++);

            foreach (string name in printerNames)
            {
                System.Console.WriteLine($"{consoleKey}:Print on {name}");
                consoleKey++;
            }

            return dictionaryNames;
        }

        private static Dictionary<int, string> ShowAvailablePrinterModels(string printerName)
        {
            int key = 1;
            int consoleKey = 1;
            var printers = manager.ShowModels(printerName);

            Dictionary<int, string> dictionaryModels = printers.OrderBy(p => p.Model).Select(p => p.Model).ToDictionary(model => key++);

            foreach (Printer p in printers)
            {
                System.Console.WriteLine($"{consoleKey} - {p.Model}");
                consoleKey++;
            }

            return dictionaryModels;
        }

        private static string GetUserChoiceOfModel(Dictionary<int, string> availableModels)
        {
            string modelNumber = System.Console.ReadLine();
           
            int modelKey = 0;
            bool converResult = int.TryParse(modelNumber.ToString(), out modelKey);

            bool isCorrectNumberModel = false;

            while (!isCorrectNumberModel)
            {
                if (converResult && availableModels.ContainsKey(modelKey))
                {
                    isCorrectNumberModel = true;
                    modelNumber= availableModels[modelKey];
                }
                else
                {
                    System.Console.WriteLine(Environment.NewLine + "Please, choice correct number of print's model.");
                    modelNumber = System.Console.ReadLine();
                    continue;
                }
            }

            return modelNumber;

        }
    }
}
