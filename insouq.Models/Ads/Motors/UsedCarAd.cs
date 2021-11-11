using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace insouq.Models
{
    // Used and scrap cars
    public class UsedCarAd
    {
        public string VIN { get; set; } // when filled >> user can fill data automatically

        [Required]
        [MaxLength(256)]
        public string Maker { get; set; }

        [Required]
        [MaxLength(256)]
        public string Model { get; set; }

        [Required]
        [MaxLength(256)]
        public string Trim { get; set; }

        [Required]
        [MaxLength(256)]
        public string Color { get; set; }

        [Required]
        public int Kilometers { get; set; }

        [Required]
        [Column(TypeName = "Date")]
        public DateTime Year { get; set; }

        [Required]
        public int Doors { get; set; }

        [Required]
        public bool Warranty { get; set; }

        [Required]
        [MaxLength(256)]
        public string Transmission { get; set; }

        [Required]
        [MaxLength(256)]
        public string RegionalSpecs { get; set; }

        [Required]
        [MaxLength(256)]
        public string BodyType { get; set; }

        [Required]
        [MaxLength(256)]
        public string FuelType { get; set; }

        [Required]
        [MaxLength(256)]
        public string NoOfCylinders { get; set; }

        [Required]
        [MaxLength(256)]
        public string Horsepower { get; set; }

        [Required]
        [MaxLength(256)]
        public string CarCondition { get; set; }

        [Required]
        [MaxLength(256)]
        public string MechanicalCondition { get; set; }

        [Required]
        [Range(1000, double.MaxValue)]
        public double Price { get; set; } // min 1000

    }
}
