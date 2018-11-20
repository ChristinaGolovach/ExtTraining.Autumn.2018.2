﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        //TODO make return string
        public void Print(FileStream fs)
        {
            StartPrint();
            PrintCore(fs);
            EndPrint();
        }

        //TODO or make partiol implementation here
        protected abstract void StartPrint();
        protected abstract void EndPrint();

        protected abstract string PrintCore(FileStream fs);

        protected virtual void OnPrintedWork(PrinterEventArgs e)
        {
            if (ReferenceEquals(e, null))
            {
                throw new ArgumentNullException($"The {typeof(PrinterEventArgs)} can not be null.");
            }

            PrintedWork?.Invoke(this, e);
        }
    }
}
