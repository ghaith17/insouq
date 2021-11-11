using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace insouq.Models
{
    public class CommercialForSale
    {
        [Required]
        [MaxLength(256)]
        public string Furnishing { get; set; }

        [Required]
        [Range(1, double.MaxValue)]
        public double Size { get; set; }

        public bool CentralACAndHeating { get; set; }

        public bool CoveredParking { get; set; }

        public bool AvailableNetworked { get; set; }

        public bool ConferenceRoom { get; set; }

        public bool DiningInBuilding { get; set; }

        public bool RetailInBuilding { get; set; }

        public bool SharedGym { get; set; }

        public bool SharedSpa { get; set; }

        public bool ViewOfLandmark { get; set; }

        public bool ViewOfWater { get; set; }

        [Required]
        [Range(1000, double.MaxValue)]
        public double Price { get; set; } // min 1000

        public string Developer { get; set; }

        [Column(TypeName = "Date")]
        public string ReadyBy { get; set; }

        public double TotalClosingFee { get; set; }

        public double AnnualCommunityFee { get; set; }

        [MaxLength(100)]
        public string PropertyReferenceID { get; set; }

        [Required]
        [MaxLength(256)]
        public string ListedBy { get; set; }

        public string RERALandlordName { get; set; }

        public string PropertyStatus { get; set; }

        public string RERATitleDeedNumber { get; set; }

        public string RERAPreRegistrationNumber { get; set; }

        // Agent

        [MaxLength(200)]
        public string Building { get; set; }

        [Required]
        [MaxLength(200)]
        public string Neighborhood { get; set; }

        [MaxLength(256)]
        public string SubCategory { get; set; }
    }
}
