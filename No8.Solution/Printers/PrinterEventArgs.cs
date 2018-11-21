using System;

namespace No8.Solution.Printers
{
    /// <summary>
    /// Represent a class that describe printer event information. 
    /// </summary>
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
