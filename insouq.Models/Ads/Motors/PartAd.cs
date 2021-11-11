using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace insouq.Models
{
    public class PartAd
    {
        [Required]
        [Range(1000, double.MaxValue)]
        public double Price { get; set; } // min 1000

        [Required]
        [MaxLength(256)]
        public string SubCategory { get; set; }
    }
}
