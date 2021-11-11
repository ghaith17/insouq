using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace insouq.Shared.DTOS
{
    public class PropertyAdDTO : CommonAd
    {
        public List<IFormFile> Pictures { get; set; }

        public string MainPhoto { get; set; }

        public string Furnishing { get; set; }

        public int? BedRooms { get; set; }

        public int? BathRooms { get; set; }

        public double? Size { get; set; }

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

        public bool AvailableNetworked { get; set; }

        public bool ConferenceRoom { get; set; }

        public bool DiningInBuilding { get; set; }

        public bool RetailInBuilding { get; set; }

        public double? Price { get; set; } // min 1000

        public double? AnnualRent { get; set; }

        public string RentPaidIn { get; set; }

        public string Developer { get; set; }

        [Column(TypeName = "Date")]
        public DateTime? ReadyBy { get; set; }

        public double? TotalClosingFee { get; set; }

        public double? AnnualCommunityFee { get; set; }

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

        public string RERABrokerIDNumber { get; set; }

        public string RERAListerCompanyName { get; set; }

        public string RERAPermitNumber { get; set; }

        public string RERAAgentName { get; set; }

        //

        [MaxLength(200)]
        public string Building { get; set; }

        [MaxLength(200)]
        public string Neighborhood { get; set; }

        public int SubCategoryId { get; set; }
    }

}
