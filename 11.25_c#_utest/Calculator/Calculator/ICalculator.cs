using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    interface ICalculator
    {
        decimal total { get; set; }

        decimal add(decimal value);
        decimal substract(decimal value);
        decimal product(decimal value);
        decimal divide(decimal value);
    }
}
