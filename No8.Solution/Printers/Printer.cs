using System;
using System.IO;

namespace No8.Solution.Printers
{
    public abstract class Printer
    {
        public event EventHandler<PrinterEventArgs> PrintedWork = delegate { };

        private string name;
        private string model;

        public string Name
        {
           get => name;
           protected internal set => name = value ?? throw new ArgumentNullException($"The {name} can not be null.");
        }

        public string Model
        {
            get => model;
            protected internal set => model = value ?? throw new ArgumentNullException($"The {model} can not be null.");
        }

        public Printer(string model)
        {
            Model = model;
        }

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
