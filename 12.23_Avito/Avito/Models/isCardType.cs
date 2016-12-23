using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Avito.Models
{
    public class isCardType
    {
        public string Text { get
            {
                return Value ? "Yes" : "No";
            } }

        public bool Value { get; set; }
    }
}