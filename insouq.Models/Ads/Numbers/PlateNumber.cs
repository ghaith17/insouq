using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace insouq.Models
{
    public class PlateNumber
    {
        [Required]
        [MaxLength(256)]
        public string Emirate { get; set; }

        [Required]
        [MaxLength(256)]
        public string PlateType { get; set; }

        [Required]
        [MaxLength(256)]
        public string PlateCode { get; set; }

        [Required]
        [MaxLength(256)]
        public string Design { get; set; }

        [Required]
        [Range(00000, 99999)]
        public int Number { get; set; }

        public string Photo { get; set; } // auto generated
    }
}
