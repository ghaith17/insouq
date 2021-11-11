using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace insouq.Models
{
    public class MachineryAd
    {
        [Required]
        [MaxLength(256)]
        public string Manufacturer { get; set; }

        [Required]
        [MaxLength(256)]
        public string Model { get; set; }

        [Required]
        public int Kilometers { get; set; }

        [Required]
        [Column(TypeName = "Date")]
        public DateTime Year { get; set; }

        [Required]
        public bool Warranty { get; set; }

        [Required]
        [MaxLength(256)]
        public string Capacity { get; set; }

        [Required]
        [MaxLength(256)]
        public string Horsepower { get; set; }

        [Required]
        [Range(1000, double.MaxValue)]
        public double Price { get; set; } // min 1000

        [Required]
        [MaxLength(256)]
        public string SubCategory { get; set; }

        [Required]
        [MaxLength(256)]
        public string SubType { get; set; }

    }
}
