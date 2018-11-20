using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No8.Solution.Printers
{
    public class PrinterEventArgs : EventArgs
    {
        private string name;
        private string model;

        public string Name { get => name; }
        public string Model { get => model; }

        PrinterEventArgs(string name, string model)
        {
            this.name = name;
            this.model = model;
        }
    }
}
