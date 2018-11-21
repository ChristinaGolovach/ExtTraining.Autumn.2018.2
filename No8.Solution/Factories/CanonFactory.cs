﻿using System;
using No8.Solution.Printers;

namespace No8.Solution.Factories
{
    /// <summary>
    /// Implements a <see cref="T:No8.Solution.Factories.PrinterFactory"/> that designed to create an instance of <see cref="T:No8.Solution.Printers.CanonPrinter"/>
    /// </summary>
    public class CanonFactory : PrinterFactory
    {
        public override PrinterNameEnum NameFactory => PrinterNameEnum.CANON;

        /// <summary>
        /// Create a new instance of <see cref="T:No8.Solution.Printers.CanonPrinter"/>.
        /// </summary>
        /// <param name="model">The name of model.</param>
        /// <returns>
        /// Object reference to <see cref="T:No8.Solution.Printers.CanonPrinter"/>
        /// </returns>
        /// <exception cref="ArgumentNullException">The <paramref name="model"/> is null.</exception>
        public override Printer CreatePrinter(string model)
        {
            model = model ?? throw new ArgumentNullException($"The {nameof(model)} can not be null.");

            return new CanonPrinter(model);
        }
    }
}
