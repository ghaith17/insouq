using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace insouq.Models
{
    public class MobileNumber
    {
        [Required]
        [MaxLength(256)]
        public string Operator { get; set; }  
        
        [Required]
        [MaxLength(256)]
        public string CurrentNetwork { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        [Range(0000000, 9999999)]
        public int Number { get; set; }

        public string Photo { get; set; } // auto generated
    }
}
