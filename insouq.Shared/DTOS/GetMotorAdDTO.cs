using insouq.Shared.DTOS.AdPictureDTOS;
using insouq.Shared.DTOS.CategoryDTOS;
using System;
using System.Collections.Generic;
using System.Text;

namespace insouq.Shared.DTOS
{
    public class GetMotorAdDTO
    {
        public int Id { get; set; }

        public int Chates { get; set; }
        public int Views { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public string En_Location { get; set; }

        public string Ar_Location { get; set; }

        public string Lat { get; set; }

        public string Lng { get; set; }

        public int Status { get; set; } // under review or active

        public DateTime PostDate { get; set; }

        public int CategoryId { get; set; }

        public string CategoryEnName { get; set; }

        public string CategoryArName { get; set; }

        public int? SubCategoryId { get; set; }

        public string SubCategoryEn_Name { get; set; }

        public string SubCategoryAr_Name { get; set; }

        public string OtherSubCategory { get; set; }

        public int? SubTypeId { get; set; }

        public string SubTypeEn_Name { get; set; }

        public string SubTypeAr_Name { get; set; }

        public string OtherSubType { get; set; }

        public int TypeId { get; set; }

        public int? UserId { get; set; }

        public int? AgentId { get; set; }

        public List<AdPictureDTO> Pictures { get; set; }

        public string En_Maker { get; set; }

        public string Ar_Maker { get; set; }

        public string En_Model { get; set; }

        public string Ar_Model { get; set; }

        public string En_Trim { get; set; }

        public string Ar_Trim { get; set; }

        public string En_Color { get; set; }

        public string Ar_Color { get; set; }

        public double? Kilometers { get; set; }

        public int? Year { get; set; }

        public string En_Doors { get; set; }

        public string Ar_Doors { get; set; }

        public bool Warranty { get; set; }

        public string En_Transmission { get; set; }

        public string Ar_Transmission { get; set; }

        public string En_RegionalSpecs { get; set; }

        public string Ar_RegionalSpecs { get; set; }

        public string En_BodyType { get; set; }

        public string Ar_BodyType { get; set; }

        public string En_FuelType { get; set; }

        public string Ar_FuelType { get; set; }

        public string En_NoOfCylinders { get; set; }

        public string Ar_NoOfCylinders { get; set; }

        public string En_Horsepower { get; set; }

        public string Ar_Horsepower { get; set; }

        public string En_Condition { get; set; }

        public string Ar_Condition { get; set; }

        public string En_MechanicalCondition { get; set; }

        public string Ar_MechanicalCondition { get; set; }

        public double? Price { get; set; } // min 1000

        public string En_Capacity { get; set; }

        public string Ar_Capacity { get; set; }

        public string En_EngineSize { get; set; }

        public string Ar_EngineSize { get; set; }

        public string En_Age { get; set; }

        public string Ar_Age { get; set; }

        public string En_Usage { get; set; }

        public string Ar_Usage { get; set; }

        public string En_Length { get; set; }

        public string Ar_Length { get; set; }

        public string En_Wheels { get; set; }

        public string Ar_Wheels { get; set; }

        public string En_SellerType { get; set; }

        public string Ar_SellerType { get; set; }

        public string En_FinalDriveSystem { get; set; }

        public string Ar_FinalDriveSystem { get; set; }

        public string En_SteeringSide { get; set; }

        public string Ar_SteeringSide { get; set; }  
        
        public string En_PartName { get; set; }

        public string Ar_PartName { get; set; }

        public string NameOfPart { get; set; }

        public string UserImage { get; set; }

        public string PhoneNumber { get; set; }

        public bool IsFavorite { get; set; }

       
    }
}
