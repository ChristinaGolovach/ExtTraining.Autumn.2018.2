using System;

namespace No8.Solution.Printers
{
    public class PrinterEventArgs : EventArgs
    {
        private string name;
        private string model;
        private string info;

        public string Name { get => name; }
        public string Model { get => model; }
        public string Info { get => info; }

        public PrinterEventArgs(string name, string model, string info)
        {
            this.name = name;
            this.model = model;
            this.info = info;
        }
    }
}
