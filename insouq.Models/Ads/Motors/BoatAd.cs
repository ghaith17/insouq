using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace insouq.Models
{
    public class BoatAd
    {
        [Required]
        [MaxLength(256)]
        public string Manufacturer { get; set; }

        [Required]
        [MaxLength(256)]
        public string EngineSize { get; set; }

        [Required]
        [MaxLength(256)]
        public string Horsepower { get; set; }

        [Required]
        [MaxLength(256)]
        public string Age { get; set; }

        [Required]
        [MaxLength(256)]
        public string Usage { get; set; }

        [Required]
        [MaxLength(256)]
        public string Condition { get; set; }

        [Required]
        [MaxLength(256)]
        public string Length { get; set; }

        [Required]
        public bool Warranty { get; set; }

        [Required]
        [Range(1000, double.MaxValue)]
        public double Price { get; set; } // min 1000

        [Required]
        [MaxLength(256)]
        public string SubCategory { get; set; }
    }
}
