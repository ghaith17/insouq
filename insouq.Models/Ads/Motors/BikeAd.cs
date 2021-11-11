using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace insouq.Models
{
    public class BikeAd
    {
        [Required]
        [MaxLength(256)]
        public string Manufacturer { get; set; }

        [Required]
        [MaxLength(256)]
        public string Model { get; set; }

        [Required]
        [MaxLength(256)]
        public string Color { get; set; }

        [Required]
        public int Kilometers { get; set; }

        [Required]
        [Column(TypeName = "Date")]
        public DateTime Year { get; set; }

        [Required]
        public bool Warranty { get; set; }

        [Required]
        [MaxLength(256)]
        public string FuelType { get; set; }

        [Required]
        [MaxLength(256)]
        public string EngineSize { get; set; }

        [Required]
        [MaxLength(256)]
        public string Horsepower { get; set; }

        [Required]
        [MaxLength(256)]
        public string Wheels { get; set; }

        [Required]
        [Range(1000, double.MaxValue)]
        public double Price { get; set; } // min 1000

    }
}
