using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace insouq.Models
{
    public class ResidentialForRent
    {
        [Required]
        [MaxLength(256)]
        public string Furnishing { get; set; }

        [Range(1, 100)]
        public int BedRooms { get; set; }

        public int BathRoom { get; set; }

        [Required]
        [Range(1, double.MaxValue)]
        public double Size { get; set; }

        public bool Balcony { get; set; }

        public bool BuiltInKitchenAppliances { get; set; }

        public bool BuildInWardrobes { get; set; }

        public bool WalkInCloset { get; set; }

        public bool CentralACAndHeating { get; set; }

        public bool ConceirgeService { get; set; }

        public bool CoveredParking { get; set; }

        public bool MaidService { get; set; }

        public bool MaidsRoom { get; set; }

        public bool PetsAllowed { get; set; }

        public bool PrivateGarden { get; set; }

        public bool PrivateGym { get; set; }

        public bool PrivateJacuzzi { get; set; }

        public bool PrivatePool { get; set; }

        public bool Security { get; set; }

        public bool SharedGym { get; set; }

        public bool SharedPool { get; set; }

        public bool SharedSpa { get; set; }

        public bool StudyRoom { get; set; }

        public bool ViewOfLandmark { get; set; }

        public bool ViewOfWater { get; set; }

        [Required]
        [Range(1, double.MaxValue)]
        public double AnnualRent { get; set; }

        [Required]
        public string RentPaidIn { get; set; }

        public string Developer { get; set; }

        [Column(TypeName = "Date")]
        public string ReadyBy { get; set; }


        [MaxLength(100)]
        public string PropertyReferenceID { get; set; }

        [Required]
        [MaxLength(256)]
        public string ListedBy { get; set; }

        public string RERALandlordName { get; set; }

        public string PropertyStatus { get; set; }

        public string RERATitleDeedNumber  { get; set; }

        public string RERAPreRegistrationNumber   { get; set; }

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
