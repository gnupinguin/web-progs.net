using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Calculator: ICalculator
    {
        public decimal total{ get; set; }

        public decimal add(decimal value)
        {
            return total += value;
        }
        public decimal substract(decimal value)
        {
            return total -= value;
        }
        public decimal product(decimal value)
        {
            return total *= value;
        }
        public decimal divide(decimal value)
        {
            return total /= value;
        }
    }
}
