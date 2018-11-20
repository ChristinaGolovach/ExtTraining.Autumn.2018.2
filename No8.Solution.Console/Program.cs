using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using No8.Solution;
using No8.Solution.Printers;
using System.Windows.Forms;

namespace No8.Solution.Console
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            //PrinterManager manager = new PrinterManager();
            System.Console.WriteLine("Select your choice:");
            System.Console.WriteLine("1:Add new printer");
            System.Console.WriteLine("2:Print on Canon");
            System.Console.WriteLine("3:Print on Epson");

            var key = System.Console.ReadKey();

            if (key.Key == ConsoleKey.D1)
            {
                CreatePrinter();
            }

            if (key.Key == ConsoleKey.D2)
            {
                Print(PrinterNameEnum.Canon);
            }

            if (key.Key == ConsoleKey.D3)
            {
                Print(PrinterNameEnum.Epson);
            }

            while (true)
            {
                // waiting
            }
        }

        private static void Print(PrinterNameEnum printer)
        {
            System.Console.WriteLine($"Choise printer model for {printer.ToString()}");

            var printers = PrinterManager.ShowModels(printer);     

            foreach (Printer p in printers)
            {  
                System.Console.WriteLine($"{p.Model}");
            }
            
            string model = System.Console.ReadLine();

            var fileDialog = new OpenFileDialog();
            fileDialog.ShowDialog();

            string fileName = fileDialog.FileName;

            PrinterManager.Print(printers.FirstOrDefault(p => p.Model == model), fileName);
            
        }

        private static void CreatePrinter()
        {
            System.Console.WriteLine("Enter printer name");

            string name = System.Console.ReadLine();

            System.Console.WriteLine("Enter printer model");

            string model = System.Console.ReadLine();

            PrinterManager.Add(name, model);
        }    
    }
}
