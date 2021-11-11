using insouq.Shared.DTOS.AdPictureDTOS;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace insouq.Shared.DTOS
{
    public class GetPropertyAdDTO
    {
        public int Chates { get; set; }

        public int Views { get; set; }
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string En_Location { get; set; }

        public string Ar_Location { get; set; }

        public string Lat { get; set; }

        public string Lng { get; set; }

        public int Status { get; set; } // under review or active

        public DateTime PostDate { get; set; }

        public int CategoryId { get; set; }

        public string CategoryArName { get; set; }

        public string CategoryEnName { get; set; }

        public int TypeId { get; set; }

        public int? UserId { get; set; }

        public int? AgentId { get; set; }

        public List<AdPictureDTO> Pictures { get; set; }

        public string En_Furnishing { get; set; }

        public string Ar_Furnishing { get; set; }

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

        public string En_RentPaidIn { get; set; }

        public string Ar_RentPaidIn { get; set; }

        public string Developer { get; set; }

        [Column(TypeName = "Date")]
        public DateTime? ReadyBy { get; set; }

        public double? TotalClosingFee { get; set; }

        public double? AnnualCommunityFee { get; set; }

        public string PropertyReferenceID { get; set; }

        public string ListedBy { get; set; }

        public string RERALandlordName { get; set; }

        public string En_PropertyStatus { get; set; }

        public string Ar_PropertyStatus { get; set; }

        public string RERATitleDeedNumber { get; set; }

        public string RERAPreRegistrationNumber { get; set; }

        public string RERABrokerIDNumber { get; set; }

        public string RERAListerCompanyName { get; set; }

        public string RERAPermitNumber { get; set; }

        public string RERAAgentName { get; set; }

        public string Building { get; set; }

        public string Neighborhood { get; set; }

        public int SubCategoryId { get; set; }

        public string SubCategoryEn_Name { get; set; }

        public string SubCategoryAr_Name { get; set; }

        public string UserImage { get; set; }
    }

}
