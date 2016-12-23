using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace Avito.Models
{
    public class Record
    {
        [Required(ErrorMessage ="Input name with 2 characters")]
        [MinLength(2)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Input phone with 10 numbers")]
        [Range(1000000000, 10000000000)]
        public long PhoneNumber { get; set; }

        public string Address { get; set; }
        public string Text { get; set; }
        public bool isCard { get; set; }
    }
}